namespace PetHouse.ContractsDto.Usuario
{
    public class UsuarioParaCriacaoDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string TipoUsuarioStr { get; set; }
    }
}
