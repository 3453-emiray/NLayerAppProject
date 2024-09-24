using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Service.Services;
using NLayer.API.Controllers;
using NLayer.Core.Services;
using Autofac.Core;
using NLayer.API.Filters;

namespace NLayer.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;       
        private readonly IProductService _service;
        public ProductsController(IMapper mapper, IProductService productService)
        {            
            _mapper = mapper;
            _service = productService;
        }

        /// GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWitCategory());
        }

        [HttpGet] /// GET api/products
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDto = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }

    [ServiceFilter(typeof(NotFoundFilter<Product>))] 
        [HttpGet("{id}")] /// GET api/products/5
        public async Task<IActionResult> GetById(int id)
        {
            var products = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(products);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
        }
        [HttpPost] 
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto) // productupdate dto yerine product yazılmıştı ve buyuzden pud schemasta görünmedi ve put işleminde created date göründü sonra düzelttim
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));            
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")] /// DELETE api/products/5
        public async Task<IActionResult> Remove(int id)
        {
            var Product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Product);          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

    }
}
