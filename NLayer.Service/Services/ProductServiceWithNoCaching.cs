using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Core.Repositories;
using NLayer.Core.DTOs;
using AutoMapper;
using NLayer.Core.Models;
using System.Collections.Generic;

namespace NLayer.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper,IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategory()
        {               
            var products= await _productRepository.GetProductsWitCategory();
            var productsDto= _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
