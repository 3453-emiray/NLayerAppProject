using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Category : BaseEntity //BaseEntityden miras alıyoruz
    {
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } //ICollection<Product> birden fazlo product ı olabilir
    }
}
