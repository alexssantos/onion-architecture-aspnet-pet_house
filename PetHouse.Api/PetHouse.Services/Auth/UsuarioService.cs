using PetHouse.ContractsDto.Auth;
using PetHouse.Domain.Repositories;
using PetHouse.Domain.Usuarios.Enum;
using PetHouse.Services.Abstractios;

namespace PetHouse.Services.Auth
{
    internal sealed class UsuarioService : IUsuarioService
    {
        public IRepositoryManager RepositoryManager { get; set; }

        public UsuarioService(IRepositoryManager repositoryManager)
        {
            RepositoryManager = repositoryManager;
        }

        public UsuarioParaLoginDto ObterUsuarioParaLogin()
        {
            return new UsuarioParaLoginDto()
            {
                Email = "alex@gmail.com",
                Login = "alex123",
                Nome = "Alex",
                TipoUsuarioStr = UsuarioTipo.FUNCIONARIO.ToString()
            };
        }
    }
}
