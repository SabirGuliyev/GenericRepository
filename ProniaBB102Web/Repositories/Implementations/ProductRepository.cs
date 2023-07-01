using Microsoft.EntityFrameworkCore;
using ProniaBB102Web.DAL;
using ProniaBB102Web.Models;
using ProniaBB102Web.Repositories.Implementations.Generic;
using ProniaBB102Web.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProniaBB102Web.Repositories.Implementations
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context)
        {

        }
    }
}
