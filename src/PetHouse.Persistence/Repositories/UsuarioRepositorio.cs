using PetHouse.Domain.Repositories;
using PetHouse.Domain.Usuarios;
using PetHouse.Persistence.Database;
using PetHouse.Persistence.Repositories.Base;

namespace PetHouse.Persistence.Repositories
{
    internal sealed class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepository(PetHouseContext context) : base(context)
        {
        }
    }
}
