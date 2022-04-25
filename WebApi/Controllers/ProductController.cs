using AutoMapper;
using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IServices<Product> _service;
        public ProductController(IMapper mapper, IServices<Product> service)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }
        [HttpGet("id")]
        public async Task<IActionResult>GetById(int id)
        {
            var product = await _service.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }
        [HttpPost]
        public async Task<IActionResult>Create(ProductDto productDto)
        {
            var products = _mapper.Map<Product>(productDto);
            var result = await _service.Add(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201,productDto));
        }
        [HttpPut]
        public async Task<IActionResult>Update(ProductDto productDto)
        {
            await _service.Update(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentResult>.Success(204));
        }
        [HttpDelete("id")]
        public async Task<IActionResult>Remove(int id)
        {
            var product = await _service.GetById(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentResult>.Fail(404, "İlgili product bulunamadı"));
            }
            await _service.Remove(product);
            return CreateActionResult(CustomResponseDto<NoContentResult>.Success(204));
        }
    }
}
