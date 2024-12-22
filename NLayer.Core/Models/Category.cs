namespace NLayer.Core.Models
{
    public class Category : BaseEntity //BaseEntityden miras alıyoruz
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } //ICollection<Product> birden fazlo product ı olabilir
    }
}
