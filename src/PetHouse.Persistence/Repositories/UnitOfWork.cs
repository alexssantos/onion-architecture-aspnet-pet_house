using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;

namespace PetHouse.Persistence.Repositories
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly PetHouseContext _dbContext;

        public UnitOfWork(PetHouseContext dbContext) => _dbContext = dbContext;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);

        public int SaveChanges() =>
            _dbContext.SaveChanges();
    }
}
