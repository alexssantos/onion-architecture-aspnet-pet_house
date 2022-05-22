using PetHouse.ContractsDto.Auth;

namespace PetHouse.Services.Abstractios
{
    public interface IAuthService
    {
        string GerarToken(UsuarioParaLoginDto usuario);
    }
}
