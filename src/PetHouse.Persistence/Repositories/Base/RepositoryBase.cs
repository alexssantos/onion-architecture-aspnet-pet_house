using Microsoft.EntityFrameworkCore;
using PetHouse.Domain.Commons;
using PetHouse.Domain.Repositories;
using PetHouse.Persistence.Database;
using System.Linq.Expressions;

namespace PetHouse.Persistence.Repositories.Base
{
    internal class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly DbSet<T> _queryOfEntity;
        protected readonly PetHouseContext _context;

        public RepositoryBase(PetHouseContext context)
        {
            _context = context;
            _queryOfEntity = _context.Set<T>();
        }

        public T Delete(Guid id)
        {
            var entity = _queryOfEntity.Find(id);
            if (entity == null) return entity;

            _queryOfEntity.Remove(entity);
            return entity;
        }

        public IList<T> GetAll()
        {
            return _queryOfEntity.ToList();
        }

        public async Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _queryOfEntity.ToListAsync(cancellationToken);
        }

        public IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return this._queryOfEntity.Where(expression).ToList();
        }

        public async Task<IList<T>> GetAllByCriteriaAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _queryOfEntity.Where(expression).ToListAsync(cancellationToken);
        }

        public T GetbyId(Guid id)
        {
            return _queryOfEntity.FirstOrDefault(x => x.Id == id);
        }

        public async Task<T> GetbyIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _queryOfEntity.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public T GetOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return _queryOfEntity.FirstOrDefault(expression);
        }

        public async Task<T> GetOneByCriteriaAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _queryOfEntity.FirstOrDefaultAsync(expression, cancellationToken);
        }

        public T Insert(T entity)
        {
            _queryOfEntity.Add(entity);
            return entity;
        }
        public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _queryOfEntity.AddAsync(entity, cancellationToken);
            return entity;
        }

        public T Update(Guid id, T entity)
        {
            _queryOfEntity.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void InsertMany(ICollection<T> entities)
        {
            _queryOfEntity.AddRange(entities);
        }

        public async Task InsertManyAsync(ICollection<T> entities, CancellationToken cancellationToken = default)
        {
            await _queryOfEntity.AddRangeAsync(entities, cancellationToken);
        }
    }
}
