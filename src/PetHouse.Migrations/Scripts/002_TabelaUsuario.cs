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
                .WithColumn("id_usuario").AsInt32().PrimaryKey()
                .WithColumn("str_password").AsString(120).NotNullable()
                .WithColumn("int_tipo").AsInt16().NotNullable()
                .WithColumn("str_email").AsString(120).NotNullable()
                .WithColumn("str_nome").AsString(120).NotNullable()
                .WithColumn("dt_nascimento").AsDateTime2().NotNullable()
                .WithColumn("dt_criacao").AsDateTime2().NotNullable()
                .WithColumn("dt_atualizacao").AsDateTime2();
        }
    }
}
