using PetHouse.Domain.Repositories;
using PetHouse.Domain.Usuarios;
using PetHouse.Persistence.Database;
using PetHouse.Persistence.Repositories.Base;

namespace PetHouse.Persistence.Repositories
{
    internal sealed class UsuarioRepositorio : RepositoryBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(PetHouseContext context) : base(context)
        {
        }
    }
}
