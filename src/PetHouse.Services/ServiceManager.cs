using Microsoft.Extensions.Configuration;
using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;
using PetHouse.Services.Auth;
using PetHouse.Services.Pets;

namespace PetHouse.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _lazyAuthService;
        private readonly Lazy<IUsuarioService> _lazyUsuarioService;
        private readonly Lazy<IPetService> _lazyPetService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(configuration, repositoryManager));
            _lazyUsuarioService = new Lazy<IUsuarioService>(() => new UsuarioService(repositoryManager));
            _lazyPetService = new Lazy<IPetService>(() => new PetService(repositoryManager));
        }

        public IAuthService AuthService => _lazyAuthService.Value;
        public IUsuarioService UsuarioService => _lazyUsuarioService.Value;
        public IPetService PetService => _lazyPetService.Value;
    }
}
