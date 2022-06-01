using System.Text.Json.Serialization;

namespace PetHouse.ContractsDto.Auth
{
    public class UsuarioDto
    {
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }

        [JsonPropertyName("tipo")]
        public string TipoUsuarioStr { get; set; }
    }
}
