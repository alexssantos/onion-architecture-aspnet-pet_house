namespace PetHouse.Services.Abstractios
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IUsuarioService UsuarioService { get; }
        IPetService PetService { get; }
        IConsultaVeterinariaService ConsultaVeterinariaService { get; }
    }
}
