using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pyronet.Core.Entities;

namespace pyronet.Repo.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Product {get; set;}        
        public DbSet<ProductType> ProductType {get; set;}
        public DbSet<ProductBrand> ProductBrand {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName=="Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach(var enttytyType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties=enttytyType.ClrType.GetProperties().Where(p=>p.PropertyType==typeof(decimal));
                    foreach(var property in properties)
                    {
                        modelBuilder.Entity(enttytyType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}