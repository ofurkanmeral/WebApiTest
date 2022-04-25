﻿using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IProductService:IServices<Product>
    {
        //Task<List<ProductWithCategoryDto>> GetProductWithCategory();
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory();
    }
}
