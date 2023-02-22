using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Shared.Models.Seed
{
    public class CategorySeed
    {
        public static void AddSeedData(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
            new Category
            {
                Id = SalesOrderContstants.CategoryId1,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                CategoryCode = SalesOrderContstants.CategoryCode1,
                Description = "Category #1 Mock",
                IsActive = true,
            },
            new Category
            {
                Id = SalesOrderContstants.CategoryId2,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                CategoryCode = SalesOrderContstants.CategoryCode2,
                Description = "Category #2 Mock",
                IsActive = true,
            },
            new Category
            {
                Id = SalesOrderContstants.CategoryId3,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                CategoryCode = SalesOrderContstants.CategoryCode3,
                Description = "Category #3 Mock",
                IsActive = true,
            });
        }
    }
}