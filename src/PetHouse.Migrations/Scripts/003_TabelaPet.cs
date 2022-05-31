using FluentMigrator;

namespace PetHouse.Migrations.Scripts
{
    [Migration(3, "_003_TabelaPet")]
    public class _003_TabelaPet : Migration
    {
        public override void Down()
        {
            Delete.Table("pet");
        }

        public override void Up()
        {
            Create.Table("pet")
                .WithColumn("id_pet").AsGuid().PrimaryKey()
                .WithColumn("str_nome").AsString(120)
                .WithColumn("str_nome_dono").AsString(120)
                .WithColumn("dt_nascimento").AsDateTime2()
                .WithColumn("dt_criacao").AsDateTime2()
                .WithColumn("dt_atualizacao").AsDateTime2().Nullable();
        }
    }
}
