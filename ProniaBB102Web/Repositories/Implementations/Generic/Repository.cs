using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Repositories.Interfaces.Generic;
using System.Linq.Expressions;

namespace ProniaBB102Web.Repositories.Implementations.Generic
{
    public class Repository<T>:IRepository<T> where T:BaseEntity
    {
        private readonly AppDbContext _context;
        public DbSet<T> _dbSet;


        public Repository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task CreateAsync(T T)
        {
            await _dbSet.AddAsync(T);
        }

        public void Delete(T T)
        {
           _dbSet.Remove(T);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> func = null, params string[] includes)
        {
            IQueryable<T> query =_dbSet.AsQueryable();
            if (func != null)
            {
                query.Where(func);
            }
            query = GetIncludes(query, includes);

            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> func, params string[] includes)
        {
            IQueryable<T> query =_dbSet.AsQueryable();

            query = GetIncludes(query, includes);
            return await query.FirstOrDefaultAsync(func);
        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            //_context.Ts.Include("TTag").Include("TTag.Tag");

            IQueryable<T> query =_dbSet.AsQueryable();

            query = GetIncludes(query, includes);
            return await query.FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<T> GetIncludes(IQueryable<T> items, params string[] includes)
        {

            if (includes != null)
            {
                foreach (string item in includes)
                {
                    items = items.Include(item);
                }
            }
            return items;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T T)
        {
           _dbSet.Update(T);
        }


    }
}
