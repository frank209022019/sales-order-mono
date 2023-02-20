using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Database.Models.Seed
{
    public class ProductSeed
    {
        public static void AddSeedData(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
            new Product
            {
                Id = SalesOrderContstants.ProductId1,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                ProductCode = SalesOrderContstants.ProductCode1,
                Description = "Category #1 Mock",
                IsActive = true,
            },
            new Product
            {
                Id = SalesOrderContstants.ProductId2,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                ProductCode = SalesOrderContstants.ProductCode2,
                Description = "Category #2 Mock",
                IsActive = true,
            },
            new Product
            {
                Id = SalesOrderContstants.ProductId3,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                ProductCode = SalesOrderContstants.ProductCode3,
                Description = "Category #3 Mock",
                IsActive = true,
            });
        }
    }
}