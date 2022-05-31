using FluentMigrator;

namespace PetHouse.Migrations.Scripts
{
    [Migration(4, "_004_TabelaConsultaVeterinaria")]
    public class _004_TabelaConsultaVeterinaria : Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("fk_pet_consulta_veterianaria_id_usuario")
                .OnTable("consulta_veterinaria");
            Delete.ForeignKey("fk_usuario_consulta_veterianaria_id_usuario")
                .OnTable("consulta_veterinaria");

            Delete.Table("consulta_veterinaria");
        }

        public override void Up()
        {
            Create.Table("consulta_veterinaria")
                .WithColumn("id_consulta_veterinaria").AsGuid().PrimaryKey()

                .WithColumn("id_pet").AsGuid()
                    .ForeignKey("fk_pet_consulta_veterianaria_id_usuario", "pet", "id_pet")
                .WithColumn("id_agendador").AsGuid()
                    .ForeignKey("fk_usuario_consulta_veterianaria_id_usuario", "usuario", "id_usuario")

                .WithColumn("str_descricao").AsString(400)
                .WithColumn("dt_consulta").AsDateTime2()
                .WithColumn("dt_criacao").AsDateTime2()
                .WithColumn("dt_atualizacao").AsDateTime2().Nullable();
        }
    }
}
