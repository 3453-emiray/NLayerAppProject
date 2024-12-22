using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap(); // ReverseMap() sayesinde ProductDto yu Producta da çevirebiliriz
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>(); //.ReverseMap()
            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
