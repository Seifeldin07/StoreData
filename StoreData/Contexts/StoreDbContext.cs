using Microsoft.EntityFrameworkCore;
using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Contexts
{
    public class StoreDbContext : DbContext
    {
        private DbSet<DeliveryMethods> deliveryMethods;

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet <Product> Products { get; set; }
        public DbSet <ProductBrand> ProductBrands { get; set; }
        public DbSet <ProductType> ProductTypes { get; set; }

        //public DbSet<DeliveryMethods> DeliveryMethods { get; set; }




    }
}
