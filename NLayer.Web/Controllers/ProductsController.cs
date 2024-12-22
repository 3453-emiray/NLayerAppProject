using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.Web.Services;


namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;

        public ProductsController(CategoryApiService categoryApiService, ProductApiService productApiService)
        {
            _categoryApiService = categoryApiService;
            _productApiService = productApiService;
        }

        /*private readonly IProductService _services;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService services, ICategoryService categoryService, IMapper mapper)
        {
            _services = services;
            _categoryService = categoryService;
            _mapper = mapper;
        }*/ //api den DTO'lu halde geldiği için burayı kapattım.

        public async Task<IActionResult> Index()
        {
            return View(await _productApiService.GetProductsWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var categoriesDto = await _categoryApiService.GetAllAsync();

            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _productApiService.SaveAsync(productDto);                
                return RedirectToAction(nameof(Index));
            }
            var categoriesDto = await _categoryApiService.GetAllAsync();
            
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);

            var categoriesDto = await _categoryApiService.GetAllAsync();
                       
            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name",product.CategoryId);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid) 
            {                
                await _productApiService.UpdateAsync(productDto);
                return RedirectToAction(nameof(Index));
            }

            var categoriesDto = await _categoryApiService.GetAllAsync();            

            ViewBag.Categories = new SelectList(categoriesDto, "Id", "Name", productDto.CategoryId);

            return View(productDto);
        }

        public async Task<IActionResult> Remove(int id) 
        {            
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
