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
        T Save(T entity);
        T SaveAsync(T entity, CancellationToken cancellationToken = default);
        void SaveMany(ICollection<T> entities);
        Task SaveManyAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
        T Update(Guid id, T entity);
        T Delete(Guid id);
        T GetOneByCriteria(Expression<Func<T, bool>> expression);
        IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression);
    }
}
