using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesOrder.Shared.Models.Seed;

namespace SalesOrder.Shared.Models.Configurations
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductCode)
              .IsRequired()
              .HasMaxLength(10);

            builder.Property(i => i.Description)
             .IsRequired()
             .HasMaxLength(50);

            builder.Property(i => i.Price)
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
            ProductSeed.AddSeedData(builder);
        }
    }
}