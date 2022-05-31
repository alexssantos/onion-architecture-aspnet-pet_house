using Microsoft.Extensions.Configuration;
using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;
using PetHouse.Services.Auth;
using PetHouse.Services.Consultas;
using PetHouse.Services.Pets;

namespace PetHouse.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthService> _lazyAuthService;
        private readonly Lazy<IUsuarioService> _lazyUsuarioService;
        private readonly Lazy<IPetService> _lazyPetService;
        private readonly Lazy<IConsultaVeterinariaService> _lazyConsultaVeterinariaService;

        public ServiceManager(IRepositoryManager repositoryManager, IConfiguration configuration)
        {
            _lazyAuthService = new Lazy<IAuthService>(() => new AuthService(configuration, repositoryManager));
            _lazyUsuarioService = new Lazy<IUsuarioService>(() => new UsuarioService(repositoryManager));
            _lazyPetService = new Lazy<IPetService>(() => new PetService(repositoryManager));
            _lazyConsultaVeterinariaService = new Lazy<IConsultaVeterinariaService>(() => new ConsultaVeterinariaService(repositoryManager));
        }

        public IAuthService AuthService => _lazyAuthService.Value;
        public IUsuarioService UsuarioService => _lazyUsuarioService.Value;
        public IPetService PetService => _lazyPetService.Value;
        public IConsultaVeterinariaService ConsultaVeterinariaService => _lazyConsultaVeterinariaService.Value;
    }
}
