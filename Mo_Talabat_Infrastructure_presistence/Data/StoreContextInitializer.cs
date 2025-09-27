using Microsoft.EntityFrameworkCore;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Core_Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Data
{
    internal class StoreContextInitializer(StoreContext dbContext) : IStoreContextInitializer
    {
        public async Task InitializeAsync()
        {
            var PendingMigrations =await dbContext.Database.GetPendingMigrationsAsync();

            if (PendingMigrations.Any())
            {
                await dbContext.Database.MigrateAsync();
            }
        }
        public async Task SeedAsync()
        {
             //Brand seeding
             if(!dbContext.Brands.Any())
            {
                var BrandsData =await File.ReadAllTextAsync($"../Mo_Talabat_Infrastructure_presistence/Data/Seeds/Json Data/brands.json");
                var barnds= JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
                if (barnds?.Count() > 0)
                {
                    await dbContext.AddRangeAsync(barnds);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Categories.Any())
            {
                var CategoriesData = await File.ReadAllTextAsync($"../Mo_Talabat_Infrastructure_presistence/Data/Seeds/Json Data/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCatrgory>>(CategoriesData);
                if (categories?.Count() > 0)
                {
                    await dbContext.AddRangeAsync(categories);
                    await dbContext.SaveChangesAsync();
                }
            }

            if (!dbContext.Products.Any())
            {
                var ProductsData = await File.ReadAllTextAsync($"../Mo_Talabat_Infrastructure_presistence/Data/Seeds/Json Data/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
                if (products?.Count() > 0)
                {
                    await dbContext.AddRangeAsync(products);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
