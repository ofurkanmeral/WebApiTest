﻿using AutoMapper;
using Core;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product>repository,IUnitOfWork unitOfWork,IMapper mapper,IProductRepository productRepository):base(repository,unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductWithCategory()
        {
            var products = await _productRepository.GetProductWithCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
