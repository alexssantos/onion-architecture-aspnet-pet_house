using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHouse.Domain.Usuarios;

namespace PetHouse.Persistence.Database.Mappers
{
    public class UsuarioTableMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasField("id_usuario")
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Password)
                .HasField("str_password")
                .IsRequired();

            builder.Property(x => x.TipoUsuario)
                .HasField("int_tipo")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasField("str_email");

            builder.Property(x => x.Nome)
                .HasField("str_nome");

            builder.Property(x => x.DataNascimento)
                .HasField("dt_nascimento");

            // === aditamento ===
            builder.Property(x => x.DataCriacao)
                .HasField("dt_criacao")
                .IsRequired();

            builder.Property(x => x.DataUltimaAtualizacao)
                .HasField("dt_atualizacao");


            // ==== relationshiops ====

            //Nao maperar para baixo entidade com relação de herança: Admin, Cliente, Funcionario.
        }
    }
}
