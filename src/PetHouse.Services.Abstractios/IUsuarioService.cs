using PetHouse.ContractsDto.Auth;
using PetHouse.ContractsDto.Usuario;

namespace PetHouse.Services.Abstractios
{
    public interface IUsuarioService
    {
        Task<UsuarioParaLoginDto> ObterUsuarioParaLoginAsync(string email, string senha, CancellationToken cancellationToken);
        Task<UsuarioParaLoginDto> CriarUsuarioFuncionario(UsuarioParaCriacaoDto formUsuario, CancellationToken cancellationToken = default);
        Task<IEnumerable<UsuarioParaLoginDto>> ObterTodosAsync(CancellationToken cancellationToken);
    }
}
