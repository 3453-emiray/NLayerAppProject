﻿namespace NLayer.Core.Models
{
    public class Product : BaseEntity // BaseEntityden miras alıyorum
    {
        public string? Name { get; set; }  // Soru işsaretleri referans tiplerde nullable özelliğini aktif eder
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ProductFeature? ProductFeature { get; set; }

    }
}
