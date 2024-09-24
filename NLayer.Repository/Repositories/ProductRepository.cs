using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayer.Core;
using NLayer.Core.Repositories;
using NLayer.Core.Models;
using Microsoft.EntityFrameworkCore;

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


