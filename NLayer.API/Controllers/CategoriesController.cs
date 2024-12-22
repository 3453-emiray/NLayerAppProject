using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    // burada root kullanmadık çünkü CustomBaseControllerda var gerekenler
    public class CategoriesController : CustomBaseController 
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200,categoriesDto));

        }

        //api/category/GetSingleCategoryByIdWithProducts/2
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));

        }
    }
}
