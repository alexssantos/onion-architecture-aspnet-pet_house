using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Usuario>> GetAllByIdAsync(Guid userId, CancellationToken cancellationToken = default) =>
          await _queryOfEntity.Where(x => x.Id == userId).ToListAsync(cancellationToken);

        public async Task<Usuario> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default) =>
            await _queryOfEntity.FirstOrDefaultAsync(x => x.Id == accountId, cancellationToken);
    }
}
