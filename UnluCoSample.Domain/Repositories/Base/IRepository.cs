using System.Linq.Expressions;
using UnluCoSample.Domain.Entities.Base;

namespace UnluCoSample.Domain.Repositories.Base
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task Delete(int id);
    }
}
