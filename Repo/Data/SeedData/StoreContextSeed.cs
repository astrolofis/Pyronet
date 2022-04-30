using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using pyronet.Core.Entities;
using pyronet.Repo.Data;

namespace Repo.Data.SeedData
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.ProductBrand.Any())
                {
                    var brandsdata=File.ReadAllText("../Repo/Data/SeedData/brands.json");
                    var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                    foreach(var item in brands) 
                    {
                        context.ProductBrand.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.ProductType.Any())
                {
                    var typesdata=File.ReadAllText("../Repo/Data/SeedData/types.json");
                    var types=JsonSerializer.Deserialize<List<ProductType>>(typesdata);
                    foreach(var item in types)
                    {
                        context.ProductType.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Product.Any())
                {
                    var productdata=File.ReadAllText("../Repo/Data/SeedData/products.json");
                    var products=JsonSerializer.Deserialize<List<Product>>(productdata);
                    foreach(var item in products)
                    {
                        context.Product.Add(item);
                    }
                    await context.SaveChangesAsync();
                }           
            }

            catch(Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}