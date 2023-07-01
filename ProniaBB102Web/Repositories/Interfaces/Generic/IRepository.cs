using ProniaBB102Web.Models;
using System.Linq.Expressions;

namespace ProniaBB102Web.Repositories.Interfaces.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, params string[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> func, params string[] includes);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> func = null, params string[] includes);

        IQueryable<T> GetIncludes(IQueryable<T> items, params string[] includes);
        Task CreateAsync(T T);

        Task SaveChangesAsync();
        void Delete(T T);
        void Update(T T);
    }
}
