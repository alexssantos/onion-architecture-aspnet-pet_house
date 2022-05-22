using System.Runtime.Serialization;

namespace PetHouse.Domain.Usuarios.Enum
{
    [DataContract]
    public enum UsuarioTipo
    {
        [EnumMember(Value = "FUNCIONARIO")]
        FUNCIONARIO = 1,
        [EnumMember(Value = "CLIENTE")]
        CLIENTE = 2,
    }
}
