using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Pets;

namespace PetHouse.Persistence.Database.Mappers
{
    public class PetTableMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_pet")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("str_nome")
                .IsRequired();

            builder.Property(x => x.NomeDoDono)
                .HasColumnName("str_nome_dono")
                .IsRequired();

            builder.Property(x => x.DataDeNascimento)
                .HasColumnName("dt_nascimento");

            // === aditamento ===
            builder.Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao")
                .IsRequired();

            builder.Property(x => x.DataUltimaAtualizacao)
                .HasColumnName("dt_atualizacao");

            // ==== relationshiops ====            
        }
    }
}
