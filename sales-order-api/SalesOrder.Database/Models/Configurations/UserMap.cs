using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Database.Models.Seed;

namespace SalesOrder.Database.Models.Configurations
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.UserCode)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(i => i.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(i => i.LastName)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(i => i.CreatedById)
              .IsRequired();

            builder.Property(i => i.DateCreated)
                .IsRequired();

            builder.Property(i => i.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(i => i.ModifiedById).HasDefaultValue(null);

            builder.Property(i => i.DateModified).HasDefaultValue(null);

            builder.Property(i => i.DeletedById).HasDefaultValue(null);

            builder.Property(r => r.DateDeleted).HasDefaultValue(null);

            // Seed
            UserSeed.AddSeedData(builder);
        }
    }
}