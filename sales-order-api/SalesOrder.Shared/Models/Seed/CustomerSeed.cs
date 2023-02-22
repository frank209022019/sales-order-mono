using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Shared.Models.Seed
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
                Email = "golden@nomail.com",
                ContactNumber = "081-3110121",
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
                Email = "summit@nomail.com",
                ContactNumber = "051-9182102",
                IsActive = true,
            });
        }
    }
}