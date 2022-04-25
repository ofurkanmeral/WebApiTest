using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICategoryService:IServices<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryWithProductAsync(int categoryId);
    }
}
