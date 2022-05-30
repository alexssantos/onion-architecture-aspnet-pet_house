namespace PetHouse.Migrations.Utils
{
    public class ConfigUtils
    {
        public const string ENV_PRODUCTION = "prod";
        public const string ENV_DEVELOPMENT = "dev";

        public static readonly IDictionary<string, string> _dicStringConnections = new Dictionary<string, string>()
        {
            { ENV_PRODUCTION, "" },
            { ENV_DEVELOPMENT, "Server=host.docker.internal,3306;Database=infnet_pethouse;User=naruto;Password=123abc;" }
        };

        public static string Environment { get; set; } = ENV_DEVELOPMENT;

        public static string GetConnectionString() =>
            _dicStringConnections[Environment];
    }
}
