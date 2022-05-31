namespace PetHouse.Api.IoC
{
    public class AppsettingsConfiguration
    {
        public static string? EnvironmentName { get; private set; }
        public static IConfiguration? AppSetting { get; private set; }

        protected AppsettingsConfiguration() { }
        public static IConfiguration BuildToConfiguration(string environment)
        {
            EnvironmentName = environment.Replace(".", string.Empty);

            IConfigurationBuilder builder = new ConfigurationBuilder()
                           .SetBasePath(Directory.GetCurrentDirectory())
                           .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: false)
                           .AddJsonFile($"appsettings.{EnvironmentName}.json", optional: true, reloadOnChange: false)
                           .AddEnvironmentVariables();

            AppSetting = builder.Build();
            return AppSetting;
        }
    }
}
