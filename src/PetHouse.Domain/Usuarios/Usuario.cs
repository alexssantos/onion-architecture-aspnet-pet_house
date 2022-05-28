using PetHouse.Domain.Commons;
using PetHouse.Domain.Usuarios.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHouse.Domain.Usuarios
{
    [Table("usuario")]
    public class Usuario : Entity
    {
        public Usuario() { }

        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public UsuarioTipo TipoUsuario { get; set; }
    }
}
