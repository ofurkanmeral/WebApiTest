using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class CategoryController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //api/category/GetSingleCategoryWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult>GetSingleCategoryWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryWithProductAsync(categoryId));
        }
    }
}
