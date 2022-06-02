using PetHouse.Api;
using PetHouse.Api.IoC;
using Serilog;

if (args is null)
    throw new ArgumentNullException(nameof(args));

var builder = WebApplication.CreateBuilder(args);

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
IConfiguration configuration = AppsettingsConfiguration.BuildToConfiguration(environment);

var startup = new Startup(builder.Environment, configuration);
startup.ConfigureServices(builder.Services);

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