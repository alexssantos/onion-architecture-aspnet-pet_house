using MySql.Data.MySqlClient;
using PetHouse.Migrations;
using PetHouse.Migrations.Extensions;
using PetHouse.Migrations.Utils;
using System.Data;
using System.Globalization;


try
{
    Console.WriteLine("[{0}]", string.Join(", ", args));

    var (isDowngrade, version) = CheckArgs(args);

    CheckDbConnection();

    var migrationTables = new TableMigratorApp();
    if (isDowngrade)
        migrationTables.ExecuteMigrationDown(version);
    else
    {
        Console.WriteLine("Executando migrações para as tabelas");
        migrationTables.ExecuteMigrationUp();
        Console.WriteLine("Finalizou!");
        Console.ReadKey();
    }

}
catch (Exception ex)
{
    ConsoleExtensions.ShowError($"Erro devido a: {ex.Message}");
    ConsoleExtensions.ShowError("");
    ConsoleExtensions.ShowError("Para executar o processo de migração, utilize da seguinte forma:");
    ConsoleExtensions.ShowError("dotnet Escrituracao.ArquivosB3.Migracao <prod|dev> <Down|Up> <versao>");
    ConsoleExtensions.ShowError("Quando for migração de atualização, é dispensável os parâmentros.");
}


(bool, int) CheckArgs(string[] args)
{
    if (args.Length == 0) throw new Exception("Ambiente indefinido! Deve ser inserido ambiente <dev|prod>");

    ConfigUtils.Environment = args[0].Equals("prod", StringComparison.InvariantCultureIgnoreCase)
        ? ConfigUtils.ENV_PRODUCTION
        : ConfigUtils.ENV_DEVELOPMENT;

    var isDowngrade = args[1].Equals("Down", StringComparison.InvariantCultureIgnoreCase);

    int version = 0;
    var versionOk = isDowngrade && args.Length > 2
        ? int.TryParse(args[2], NumberStyles.None, CultureInfo.InvariantCulture, out version)
        : false;

    if (isDowngrade && !versionOk)
        throw new Exception("Versão não compativel! Deve ser inserido um número <versão>");

    return (isDowngrade, version);
}

void CheckDbConnection()
{
    var connectionDB = new MySqlConnection(ConfigUtils.GetConnectionString());

    try
    {
        if (connectionDB.State == ConnectionState.Closed)
            connectionDB.Open();
    }
    catch (Exception ex)
    {
        ConsoleExtensions.ShowError(
            $"Erro ao estabelecer conexao com o Banco de Dados: {ex.Message}");
        throw;
    }
    finally
    {
        if (connectionDB.State == ConnectionState.Open)
            connectionDB.Close();
    }

    connectionDB.Dispose();
}