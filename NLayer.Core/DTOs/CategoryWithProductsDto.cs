namespace NLayer.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDto
    {
        public List<ProductDto> products { get; set; }
    }
}
