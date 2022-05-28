using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PetHouse.ContractsDto.Auth
{
    [DataContract]
    public class AuthLoginRequest
    {
        [Required]
        [DataMember(Name = "usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataMember(Name = "senha")]
        public string Senha { get; set; }
    }
}
