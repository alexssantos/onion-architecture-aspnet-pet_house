using PetHouse.Api;
using PetHouse.Api.IoC;
using Serilog;

if (args is null)
    throw new ArgumentNullException(nameof(args));

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
IConfiguration configuration = AppsettingsConfiguration.BuildToConfiguration(environment);

var startup = new Startup(builder.Environment, builder.Configuration);
startup.ConfigureServices(builder.Services);


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithProperty("PetHouse.Api", "PetHouse")
    .CreateLogger();

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddSerilog(Log.Logger);
});

try
{
    var app = builder.Build();
    startup.Configure(app, app.Environment);
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Erro ao executar aplicacao");
}
finally
{
    Log.CloseAndFlush();
}