using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetHouse.Api.Configurations;
using PetHouse.Api.IoC;
using PetHouse.Api.Middleware;
using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;
using PetHouse.Persistence.Repositories;
using PetHouse.Services;
using PetHouse.Services.Abstractios;
using PetHouse.Services.Auth;
using System.Text;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace PetHouse.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration;

        public virtual void ConfigureServices(IServiceCollection services)
        {
            //Handlers/Middleware - acessar contexto das requests e manipular
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Controllers - Usando de outro projeto.
            services.AddControllers()
                .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            //Services, repositories
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            var connection = Configuration["ConnectionString:pethouse-db"];
            services.AddDbContext<PetHouseContext>(options =>
            {
                options.UseMySql(connection, MySqlServerVersion.AutoDetect(connection));
            });
            services.AddScoped<DbContext, PetHouseContext>();

            services.AddTransient<ExceptionHandlingMiddleware>();

            //Cors
            services.AddCors(options =>
                options.AddPolicy(
                    ApiStaticConfigurations.AppName,
                    builder =>
                    {
                        var origens = Configuration.GetSection(ApiStaticConfigurations.CorsHostsSection).Value?.Split(";") ?? Array.Empty<string>();
                        builder.WithOrigins(origens);
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowCredentials();
                    }));

            var secret = Configuration.GetSection(AuthSecretOptions.AuthSecret).Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //Issuer - Indica a parte que esta emitindo o JWT
                        ValidateIssuer = true,
                        ValidIssuer = "pethouse.net",
                        //Audience - Indica os destinatários do JWT;
                        ValidateAudience = true,
                        ValidAudience = "pethouse.net",
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = (context) =>
                        {
                            Console.WriteLine("Token Invalido: " + context.Exception.Message);
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = (context) =>
                        {
                            Console.WriteLine("Token Validp: " + context.SecurityToken);
                            return Task.CompletedTask;
                        }
                    };
                });

            //Serialização - lib Microsoft - config de Enum e parametor null
            services.AddMvc()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                 options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
             });

            //Swagger - habilita e config o framework
            services.UseCustomSwagger();
        }

        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.EnvironmentName.Equals(EnvironmentName.Production))
                app.UseDeveloperExceptionPage();

            //Swagger - config da UI do swagger
            //if (!env.IsEnvironment("Production"))
            app.UseCustomSwaggerUI();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.ConfigureRequestHandlingPipeline();

            app.UseEndpoints(endponts =>
            {
                endponts.MapControllers();
            });
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static void ConfigureRequestHandlingPipeline(this IApplicationBuilder app)
        {
            //middlewares - start
            app.UseRouting();

            //middleware - Habilita Cross Domain Request (compartilhamento de recurso entre Odigens)
            //  origens: {protocolo}://{Host}:{porta}. Caso algum desses parametros mudem,
            //           é uma origem diferente. Incluindo subdominios como https://api.exemplo.com:80            
            app.UseCors(ApiStaticConfigurations.AppName);

            //middleware - Redirect HTTP to HTTPS
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}

/* Notes:
 *  otima explicação sobre .net 6 Rotas, Endponts, Controllers, Actions
 *  https://stackoverflow.com/a/71933535/8941680 * 
 */
