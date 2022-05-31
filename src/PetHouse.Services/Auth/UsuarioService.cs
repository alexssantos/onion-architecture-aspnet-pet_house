using PetHouse.ContractsDto.Auth;
using PetHouse.ContractsDto.Usuario;
using PetHouse.Domain.Repositories;
using PetHouse.Domain.Usuarios;
using PetHouse.Services.Abstractios;

namespace PetHouse.Services.Auth
{
    internal sealed class UsuarioService : IUsuarioService
    {
        public IRepositoryManager _repositoryManager { get; set; }

        public UsuarioService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<UsuarioParaLoginDto> CriarUsuarioFuncionario(UsuarioParaCriacaoDto formUsuario, CancellationToken cancellationToken = default)
        {
            var usuario = await _repositoryManager.UsuarioRepositorio.GetOneByCriteriaAsync(u => u.Email.Equals(formUsuario.Email), cancellationToken);
            if (usuario != null)
            {
                throw new Exception($"Usuario {formUsuario.Email} ja cadastrado.");
            }

            var tosave = Usuario.CreateUsuario(formUsuario);

            await _repositoryManager.UsuarioRepositorio.InsertAsync(tosave, cancellationToken);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);


            return tosave.ToUsuarioLogin();
        }

        public async Task<UsuarioParaLoginDto> ObterUsuarioParaLoginAsync(string email, string senha, CancellationToken cancellationToken)
        {
            var usuario = await _repositoryManager.UsuarioRepositorio.GetOneByCriteriaAsync(u => u.Email.Equals(email), cancellationToken);

            if (usuario is null)
            {
                throw new Exception($"Usuario {email} não encontrado.");
            }
            if (!usuario.Password.Equals(senha))
            {
                throw new Exception($"Usuario {email} com senha errada.");
            }
            return usuario.ToUsuarioLogin();
        }

        public async Task<IEnumerable<UsuarioParaLoginDto>> ObterTodosAsync(CancellationToken cancellationToken)
        {
            var usuarios = await _repositoryManager.UsuarioRepositorio.GetAllAsync(cancellationToken);
            return usuarios.Select(a => a.ToUsuarioLogin());
        }
    }
}
