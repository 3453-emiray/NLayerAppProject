using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //throw new NotImplementedException();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(); //Microsoft.EntityFrameworkCore.SqlServer yüklenmesi gerekkti
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Categories");
        }
    }
}
