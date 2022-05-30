using PetHouse.Domain.Commons;
using System.Linq.Expressions;

namespace PetHouse.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : Entity
    {
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        T GetbyId(Guid id);
        Task<T> GetbyIdAsync(Guid id, CancellationToken cancellationToken = default);
        T Insert(T entity);
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
        void InsertMany(ICollection<T> entities);
        Task InsertManyAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
        T Update(Guid id, T entity);
        T Delete(Guid id);
        T GetOneByCriteria(Expression<Func<T, bool>> expression);
        Task<T> GetOneByCriteriaAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
        IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression);
        Task<IList<T>> GetAllByCriteriaAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
}
