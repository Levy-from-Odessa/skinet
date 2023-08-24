using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data.SeedData
{
  public class StoreContextSeed
  {
    public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
    {
      try
      {
        // todo: refactor
        if (!context.ProductBrands.Any())
        {
          var Data = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
          var SerializedData = JsonSerializer.Deserialize<List<ProductBrand>>(Data);
          foreach (var item in SerializedData)
          {
            await context.ProductBrands.AddAsync(item);
          }
          await context.SaveChangesAsync();
        }
        if (!context.ProductTypes.Any())
        {
          var Data = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
          var SerializedData = JsonSerializer.Deserialize<List<ProductType>>(Data);
          foreach (var item in SerializedData)
          {
            await context.ProductTypes.AddAsync(item);
          }
          await context.SaveChangesAsync();
        }

        if (!context.Products.Any())
        {
          var Data = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
          var SerializedData = JsonSerializer.Deserialize<List<Product>>(Data);
          foreach (var item in SerializedData)
          {
            await context.Products.AddAsync(item);
          }
          await context.SaveChangesAsync();
        }

      }
      catch (Exception ex)
      {
        var logger = loggerFactory.CreateLogger<StoreContextSeed>();
        logger.LogError(ex.Message);
      }
    }

    // todo: refactor
    //   private async void ImportData<T>(string path, StoreContext context, Func<T> AddFunction)
    //   {
    //     var Data = File.ReadAllText(path);
    //     var SerializedData = JsonSerializer.Deserialize<List<T>>(Data);
    //     foreach (var item in SerializedData)
    //     {
    //       await AddFunction(item);
    //     }
    //     await context.SaveChangesAsync();
    //   }
  }
}