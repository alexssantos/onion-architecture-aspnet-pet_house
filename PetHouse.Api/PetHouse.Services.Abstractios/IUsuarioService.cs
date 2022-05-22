using PetHouse.ContractsDto.Auth;

namespace PetHouse.Services.Abstractios
{
    public interface IUsuarioService
    {
        public UsuarioParaLoginDto ObterUsuarioParaLogin();
    }
}
