using PetHouse.Domain.Commons;
using System.Linq.Expressions;

namespace PetHouse.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : Entity
    {
        IList<T> GetAll();
        T GetbyId(Guid id);
        T Save(T entity);
        int SaveMany(ICollection<T> entities);
        T Update(Guid id, T entity);
        T Delete(Guid id);

        T GetOneByCriteria(Expression<Func<T, bool>> expression);
        IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression);
    }
}
