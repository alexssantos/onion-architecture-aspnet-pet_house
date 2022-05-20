using PetHouse.Api.Configurations;
using PetHouse.Api.IoC;

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
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //Swagger - config da UI do swagger
            if (!env.IsEnvironment("Production"))
                app.UseCustomSwaggerUI();

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

            app.UseAuthorization();
        }
    }
}

/* Notes:
 *  otima explicação sobre .net 6 Rotas, Endponts, Controllers, Actions
 *  https://stackoverflow.com/a/71933535/8941680 * 
 */
