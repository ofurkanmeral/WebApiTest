using AutoMapper;
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
    public class CategoryService:Service<Category>,ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper, IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductDto>> GetSingleCategoryWithProductAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryWithProductAsync(categoryId);

            var categoryDto = _mapper.Map<CategoryWithProductDto>(category);

            return CustomResponseDto<CategoryWithProductDto>.Success(200, categoryDto);
        }
    }
}
