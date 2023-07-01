using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Repositories.Implementations.Generic;
using ProniaBB102Web.Repositories.Interfaces;

namespace ProniaBB102Web.Repositories.Implementations
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {

        }


    }
}
