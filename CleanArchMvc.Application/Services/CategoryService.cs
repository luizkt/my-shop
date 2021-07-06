using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categoryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<Category, CategoryDTO>(categoryEntity);
        }

        public async Task AddAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<CategoryDTO, Category>(category);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<CategoryDTO, Category>(category);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}