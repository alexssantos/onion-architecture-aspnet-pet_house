namespace PetHouse.Api.Configurations
{
    public static class ApiStaticConfigurations
    {
        //private const string projetcName = Assembly.GetCallingAssembly().GetName().Name;
        public const string AppName = "PetHouse.Api";
        public const string CorsHostsSection = "CorsHosts";

    }

    public static class SwaggerConfiguration
    {
        public const string Version = "v1";

        public const string Title = "Pet  House - A casa dos Pets";

        public const string Endpoint = $"/swagger/{Version}/swagger.json";
    }


}
