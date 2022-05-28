using PetHouse.Domain.Usuarios;

namespace PetHouse.Domain.Repositories
{
    public interface IUsuarioRepositorio : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllByIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<Usuario> GetByIdAsync(Guid accountId, CancellationToken cancellationToken = default);
    }
}
