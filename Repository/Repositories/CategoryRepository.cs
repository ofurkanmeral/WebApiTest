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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DataContext context):base(context)
        {
        }
        public async Task<Category> GetSingleCategoryWithProductAsync(int categoryId)
        {
            //firstordefault ile signleordefault farkı şudur
            //firstordefaultda diyelim 4 tane idsi 1 olan kayıt var ilkini seçer ve getirir
            //singleordefault ise 1 den çok idsi 1 olan kayıt varsa hata döner
            return await _context.categories.Include(x => x.Products).Where(x => x.ID == categoryId).SingleOrDefaultAsync();
        }
    }
}
