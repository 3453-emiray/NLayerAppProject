using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        // AppDbContext parametresi ekleniyor
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsWitCategory()
        {
            //Eager Loading ,Datayı çekerken kategorilerde alındı
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}


