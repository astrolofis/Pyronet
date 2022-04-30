using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pyronet.Core.Entities;

namespace pyronet.Core.interfaces
{
    public interface IProductrepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypeAsync();
    }
}