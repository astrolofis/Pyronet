using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pyronet.Core.Entities;
using pyronet.Core.interfaces;

namespace pyronet.Repo.Data
{
    public class ProductRepository : IProductrepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Product.Include(p=>p.ProductBrand).Include(p=>p.ProductType).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync()
        {
            return await _context.ProductBrand.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Product.Include(p=>p.ProductBrand).Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id==id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeAsync()
        {
            return await _context.ProductType.ToListAsync();
        }
    }
}