using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Utilities;

namespace SalesOrder.Database.Models.Seed
{
    public class UserSeed
    {
        public static void AddSeedData(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            new User
            {
                Id = SalesOrderContstants.UserId1,
                CreatedById = SalesOrderContstants.UserId1,
                DateCreated = DateTime.Now.AddDays(-1000),
                UserCode = SalesOrderContstants.UserCode1,
                FirstName = "System",
                LastName = "User",
                IsActive = true,
            });
        }
    }
}