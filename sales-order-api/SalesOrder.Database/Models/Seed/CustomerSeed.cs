using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Database.Models.Seed
{
    public class CustomerSeed
    {
        public static void AddSeedData(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
            new Customer
            {
                Id = SalesOrderContstants.CustomerId1,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                CustomerCode = SalesOrderContstants.CustomerCode1,
                Name = "Golden Gate Consulting",
                Address = "123 Main Street, Anytown, USA",
                IsActive = true,
            },
            new Customer
            {
                Id = SalesOrderContstants.CustomerId2,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                CustomerCode = SalesOrderContstants.CustomerCode2,
                Name = "Summit Solutions Inc.",
                Address = "456 Oak Avenue, Somewhereville, Canada",
                IsActive = true,
            });
        }
    }
}