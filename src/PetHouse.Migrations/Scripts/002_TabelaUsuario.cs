using FluentMigrator;

namespace PetHouse.Migrations.Scripts
{
    [Migration(2, "_002_TabelaUsuario")]
    public class _002_TabelaUsuario : Migration
    {
        public override void Down()
        {
            Delete.Table("usuario");
        }

        public override void Up()
        {
            Create.Table("usuario")
                .WithColumn("id_usuario").AsGuid().PrimaryKey()
                .WithColumn("str_password").AsString(120)
                .WithColumn("int_tipo").AsInt16()
                .WithColumn("str_email").AsString(120)
                .WithColumn("str_nome").AsString(120)
                .WithColumn("dt_nascimento").AsDateTime2()
                .WithColumn("dt_criacao").AsDateTime2()
                .WithColumn("dt_atualizacao").AsDateTime2().Nullable();
        }
    }
}
