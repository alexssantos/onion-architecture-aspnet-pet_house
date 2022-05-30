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
            _context.SaveChanges();
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

        public T GetbyId(Guid id)
        {
            return _queryOfEntity.Find(id);
        }

        public async Task<T> GetbyIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _queryOfEntity.FindAsync(id, cancellationToken);
        }

        public T GetOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return _queryOfEntity.FirstOrDefault(expression);
        }

        public T Save(T entity)
        {
            _queryOfEntity.Add(entity);
            return entity;
        }
        public T SaveAsync(T entity, CancellationToken cancellationToken = default)
        {
            _queryOfEntity.AddAsync(entity, cancellationToken);
            return entity;
        }

        public T Update(Guid id, T entity)
        {
            _queryOfEntity.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public void SaveMany(ICollection<T> entities)
        {
            _queryOfEntity.AddRange(entities);
        }

        public async Task SaveManyAsync(ICollection<T> entities, CancellationToken cancellationToken = default)
        {
            await _queryOfEntity.AddRangeAsync(entities, cancellationToken);
        }
    }
}
