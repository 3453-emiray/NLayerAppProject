using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models; // ProductFeature Nlayerda tanımlı ondan dolayı sınıdın bulunduğu namespace yi eklemek gerekli


namespace NLayer.Repository.Configurations
{
    internal class ProductFeatureConfiguration : IEntityTypeConfiguration<ProductFeature>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProductFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Product).WithOne(x => x.ProductFeature).HasForeignKey<ProductFeature>(x => x.ProductId);
        }
    }
}
