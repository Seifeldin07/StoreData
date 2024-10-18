using Microsoft.Extensions.Logging;
using StoreData.Contexts;
using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreRepository
{
    public  class StoreContextSeed
    {
        public static async Task SeedAsync(StoreDbContext context, ILoggerFactory loggerFactory )
        {
            try
            {
                if (context.ProductBrands != null && !context.ProductBrands.Any())
                {
                    var brandsDate = File.ReadAllText("../StoreRepository/SeedData/brands.json");
                    var barands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsDate);

                    if (barands is not null)
                        await context.ProductBrands.AddRangeAsync(barands);
                }
                if (context.ProductTypes != null && !context.ProductTypes.Any())
                {
                    var typesData = File.ReadAllText("../StoreRepository/SeedData/types.json ");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    if (typesData is not null)
                        await context.ProductTypes.AddRangeAsync(types);
                }
                if (context.Products != null && !context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../StoreRepository/SeedData/products.json ");
                    var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                    
                    if (products is not null)
                        await context.Products.AddRangeAsync(products);
                }
                   await context.SaveChangesAsync();
                              
            }
            catch (Exception ex)
            {
                var Logger = loggerFactory.CreateLogger<StoreContextSeed>();
                Logger.LogError(ex.Message);
               
            }

        }
    }
}
