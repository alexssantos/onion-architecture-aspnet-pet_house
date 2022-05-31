using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Usuarios;

namespace PetHouse.Persistence.Database.Mappers
{
    public class UsuarioTableMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id_usuario")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("str_password")
                .IsRequired();

            builder.Property(x => x.TipoUsuario)
                .HasColumnName("int_tipo")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("str_email");

            builder.Property(x => x.Nome)
                .HasColumnName("str_nome");

            builder.Property(x => x.DataNascimento)
                .HasColumnName("dt_nascimento");

            // === aditamento ===
            builder.Property(x => x.DataCriacao)
                .HasColumnName("dt_criacao")
                .IsRequired();

            builder.Property(x => x.DataUltimaAtualizacao)
                .HasColumnName("dt_atualizacao");


            // ==== relationshiops ====

            //Nao maperar para baixo entidade com relação de herança: Admin, Cliente, Funcionario.
        }
    }
}
