using PetHouse.Domain.Commons;
using PetHouse.Domain.Usuarios.Enum;

namespace PetHouse.Domain.Usuarios
{

    public class Usuario : Entity
    {
        public Usuario() { }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public UsuarioTipo TipoUsuario { get; set; }
    }
}
