using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using PetHouse.Migrations.Scripts;
using PetHouse.Migrations.Utils;

namespace PetHouse.Migrations
{
    public class TableMigratorApp
    {

        public void ExecuteMigrationUp()
        {
            var serviceProvider = CreateServices();
            using var scope = serviceProvider.CreateScope();
            Console.WriteLine($"Executando Update para o ambiente {ConfigUtils.Environment}");
            UpdateDatabase(scope.ServiceProvider);
        }

        public void ExecuteMigrationDown(long version)
        {
            var serviceProvider = CreateServices();
            using var scope = serviceProvider.CreateScope();
            Console.WriteLine($"Executando Downgrade para o ambiente {ConfigUtils.Environment}");
            DowngradeDatabase(scope.ServiceProvider, version);
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                //Adiciona o serviço comum do FluentMigrator
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    //Adiciona suporte ao Mysql
                    .AddMySql5()
                    //Define a string de conexão
                    .WithGlobalConnectionString(ConfigUtils.GetConnectionString())
                    //Define o assembly onde estão as migrações
                    .WithMigrationsIn(typeof(_001_MigracaoInicial).Assembly))
                //Habilita o log de console no caminho do FluentMigrator
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                //Constroi o provedor de serviço
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        private static void DowngradeDatabase(IServiceProvider serviceProvider, long version)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateDown(version);
        }
    }
}
