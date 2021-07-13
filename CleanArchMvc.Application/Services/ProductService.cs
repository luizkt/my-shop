using System;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Products.Handlers;
using CleanArchMvc.Application.Products.Queries;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var getProductsQuery = new GetProductsQuery() ?? throw new Exception($"Entity could not be loaded");

            var result = await _mediator.Send(getProductsQuery);
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            if(id == null)
            {
                throw new Exception($"Product id is null");
            }
            else
            {
                var getProductByIdQuery = new GetProductByIdQuery(id.Value) ?? throw new Exception($"Entity could not be loaded");
                var result = await _mediator.Send(getProductByIdQuery);
                return _mapper.Map<Product, ProductDTO>(result); 
            }
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