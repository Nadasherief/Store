using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository
{
    public class StoreContextSeed
    {
        public static async  Task SeedAsync(StoreDbContext StoreDbContext, ILoggerFactory loggerFactory )
        {
            try
            {
                if (StoreDbContext.productBrands != null && !StoreDbContext.productBrands.Any()) 
                {
                    var brandData = File.ReadAllText("../Store.Repository/SeedData/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    if (brands is not null) {
                        await StoreDbContext.productBrands.AddRangeAsync(brands);
                    }
                }
                if (StoreDbContext.productTypes != null && !StoreDbContext.productTypes.Any())
                {
                    var ProductTypeData = File.ReadAllText("../Store.Repository/SeedData/SeedData/types.json");
                    var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);
                    if (ProductTypes is not null)
                    {
                        await StoreDbContext.productTypes.AddRangeAsync(ProductTypes);
                    }
                }
                if (StoreDbContext.products != null && !StoreDbContext.products.Any())
                {
                    var ProductData = File.ReadAllText("../Store.Repository/SeedData/SeedData/products.json");
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);
                    if (Products is not null)
                    {
                        await StoreDbContext.products.AddRangeAsync(Products);
                    }
                }
                await StoreDbContext.SaveChangesAsync();    
            }
            catch (Exception ex) {
                var logger = loggerFactory.CreateLogger<StoreDbContext>();
                logger.LogError(ex.Message);    
            }
        } 
    }
}
