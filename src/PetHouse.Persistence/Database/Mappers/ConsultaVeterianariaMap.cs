using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Consultas;

namespace PetHouse.Persistence.Database.Mappers
{
    public class ConsultaVeterianariaMap : IEntityTypeConfiguration<ConsultaVeterinaria>
    {
        public void Configure(EntityTypeBuilder<ConsultaVeterinaria> builder)
        {
            builder.ToTable("consulta_veterinaria");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_consulta_veterinaria")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.PetId)
                .HasColumnName("id_pet")
                .IsRequired();

            builder.Property(x => x.AgendadorId)
                .HasColumnName("id_agendador")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("str_descricao")
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.DataDaConsulta)
                .HasColumnName("dt_consulta")
                .IsRequired();

            // === aditamento ===
            builder.Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao")
                .IsRequired();

            builder.Property(x => x.DataUltimaAtualizacao)
                .HasColumnName("dt_atualizacao");


            // ==== relationshiops ====
            builder.HasOne(x => x.Pet)
                .WithMany(x => x.ListaDeConsultaVeterinaria)
                .HasForeignKey(x => x.PetId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Agendador)
                .WithMany(x => x.ConsultasAgendadas)
                .HasForeignKey(x => x.AgendadorId)
                .OnDelete(DeleteBehavior.NoAction);

            // navigaton prop

            builder.Navigation(e => e.Pet).AutoInclude();
            builder.Navigation(e => e.Agendador).AutoInclude();
        }
    }
}
