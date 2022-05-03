using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using pyronet.Core.Entities;

namespace Core.Specification
{
    public class ProductMapSpecification : BaseSpecification<Product>
    {
        public ProductMapSpecification()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }

        public ProductMapSpecification(int id) : base(x=> x.Id==id)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
        }
    }
}