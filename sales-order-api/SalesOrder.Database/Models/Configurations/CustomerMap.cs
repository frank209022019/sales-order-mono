using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Database.Models.Seed;

namespace SalesOrder.Database.Models.Configurations
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.CustomerCode)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(i => i.Name)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(i => i.Address)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(i => i.Email)
            .IsRequired();

            builder.Property(i => i.ContactNumber)
            .IsRequired();

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
            CustomerSeed.AddSeedData(builder);
        }
    }
}