using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataBase;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

using Models;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>/*,IProductRepository*/
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        //public Task CreateAsync(Product entity)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Product> GetAll()
        {
           
            return dbSet?.Include(p => p.Category).AsEnumerable();

        }

        //Task<List<Product>> IRepository<Product>.GetAllAsync(Expression<Func<Product, bool>>? filter, string? includeProperties, int pageSize, int pageNumber)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
