using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<Product, ProductDTO>(productEntity); 
        }
        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var productEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<Product, ProductDTO>(productEntity);
        }
        public async Task AddAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<ProductDTO, Product>(product);
            await _productRepository.CreateAsync(productEntity);
        }
        public async Task UpdateAsync(ProductDTO product)
        {
            var productEntity = _mapper.Map<ProductDTO, Product>(product);
            await _productRepository.UpdateAsync(productEntity);
        }
        public async Task RemoveAsync(int? id)
        {
            var productEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(productEntity);
        }
    }
}