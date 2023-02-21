using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesOrder.Database.Models.Configurations
{
    #region Order

    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(i => i.Id);

            builder.Property(op => op.OrderCode)
             .IsRequired();

            builder.Property(op => op.ProductTotal)
              .IsRequired();

            builder.Property(op => op.SubTotal)
               .IsRequired();

            builder.Property(op => op.TaxAmount)
               .IsRequired();

            builder.Property(op => op.Total)
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
        }
    }

    #endregion Order

    #region Order-Product

    public class OrderProductMap : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");

            builder.HasKey(i => i.Id);

            builder.HasOne(op => op.Order)
           .WithMany(o => o.OrderProducts);

            builder.HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts);

            builder.Property(op => op.Quantity)
                .IsRequired();

            builder.Property(op => op.CurrentProductPrice)
               .IsRequired();

            builder.Property(op => op.SubTotal)
               .IsRequired();

            builder.Property(op => op.TaxAmount)
               .IsRequired();

            builder.Property(op => op.Total)
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
        }
    }

    #endregion Order-Product
}