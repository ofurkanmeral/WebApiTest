using Core;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context):base(context)
        {

        }
        public async Task<List<Product>> GetProductWithCategory()
        {
            return await _context.products.Include(X => X.Category).ToListAsync();
        }
    }
}
