using PetHouse.ContractsDto.Auth;
using PetHouse.ContractsDto.Usuario;
using PetHouse.Domain.Commons;
using PetHouse.Domain.Consultas;
using PetHouse.Domain.Usuarios.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHouse.Domain.Usuarios
{
    [Table("usuario")]
    public class Usuario : Entity
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public UsuarioTipo TipoUsuario { get; set; }

        public Guid ConsultaVeterinariaId { get; set; }
        public virtual ICollection<ConsultaVeterinaria> ConsultasAgendadas { get; set; }

        public UsuarioParaLoginDto ToUsuarioLogin()
        {
            return new UsuarioParaLoginDto()
            {
                Email = Email,
                Nome = Nome,
                TipoUsuarioStr = TipoUsuario.ToString()
            };
        }

        public static Usuario CreateUsuario(UsuarioParaCriacaoDto usuarioParaCriacao)
        {
            var tipoOk = System.Enum.TryParse(usuarioParaCriacao.TipoUsuarioStr, out UsuarioTipo tipoUsuario);
            if (!tipoOk)
            {
                throw new ArgumentException($"Tipo de usuario '{ usuarioParaCriacao.TipoUsuarioStr }' é invalido");
            }

            return new Usuario
            {
                DataNascimento = usuarioParaCriacao.DataDeNascimento,
                Nome = usuarioParaCriacao.Nome,
                Email = usuarioParaCriacao.Email,
                Password = usuarioParaCriacao.Senha,
                TipoUsuario = tipoUsuario
            };
        }

    }
}
