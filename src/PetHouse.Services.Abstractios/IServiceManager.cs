namespace PetHouse.Services.Abstractios
{
    public interface IServiceManager
    {
        IAuthService AuthService { get; }
        IUsuarioService UsuarioService { get; }
    }
}
