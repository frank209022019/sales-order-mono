using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Shared.Models.Seed
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
                Name = "Product #1",
                Description = "Product #1 Description",
                Price = 20,
                IsActive = true,
            },
            new Product
            {
                Id = SalesOrderContstants.ProductId2,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                ProductCode = SalesOrderContstants.ProductCode2,
                Name = "Product #2",
                Description = "Product #2 Description",
                Price = 40,
                IsActive = true,
            },
            new Product
            {
                Id = SalesOrderContstants.ProductId3,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                ProductCode = SalesOrderContstants.ProductCode3,
                Name = "Product #3",
                Description = "Product #3 Description",
                Price = 60,
                IsActive = true,
            });
        }
    }
}