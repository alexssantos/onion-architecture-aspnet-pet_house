using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;

namespace PetHouse.Persistence.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;
        private readonly Lazy<IUsuarioRepositorio> _lazyUsuarioRepositorio;

        public RepositoryManager(PetHouseContext context)
        {
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
            _lazyUsuarioRepositorio = new Lazy<IUsuarioRepositorio>(() => new UsuarioRepositorio(context));

        }

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
        public IUsuarioRepositorio UsuarioRepositorio => _lazyUsuarioRepositorio.Value;
    }
}
