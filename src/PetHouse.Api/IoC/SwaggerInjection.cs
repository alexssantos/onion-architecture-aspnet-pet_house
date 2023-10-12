using Microsoft.OpenApi.Models;
using PetHouse.Api.Configurations;

namespace PetHouse.Api.IoC
{
    public static class SwaggerInjection
    {
        public static void ConfigureCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(x => x.First());
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc(SwaggerConfiguration.Version, new OpenApiInfo { Title = SwaggerConfiguration.Title, Version = SwaggerConfiguration.Version });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = @"JWT Authorization header using the Bearer scheme.
                    \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.
                    \r\n\r\nExample: 'Bearer 12345abcdef' ",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
        }

        public static void UseCustomSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(SwaggerConfiguration.Endpoint, SwaggerConfiguration.Title);
                c.EnableDeepLinking();
            });
        }
    }
}

/* 
 * Swagger UI - Deep Linking
 *  https://medium.com/c-sharp-progarmming/have-you-heard-of-deep-linking-in-swagger-983917ea6bb5
 */
