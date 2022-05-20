using Microsoft.OpenApi.Models;
using PetHouse.Api.Configurations;

namespace PetHouse.Api.IoC
{
    public static class SwaggerInjection
    {
        public static void UseCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(x => x.First());
                c.CustomSchemaIds(x => x.FullName);
                c.SwaggerDoc(SwaggerConfiguration.Version, new OpenApiInfo { Title = SwaggerConfiguration.Title, Version = SwaggerConfiguration.Version });
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
