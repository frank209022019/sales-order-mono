using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesOrder.Shared.Models.Configurations
{
    #region Order

    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.OrderCode)
             .IsRequired();

            builder.Property(i => i.ProductTotal)
              .IsRequired();

            builder.Property(i => i.SubTotal)
               .IsRequired();

            builder.Property(i => i.TaxAmount)
               .IsRequired();

            builder.Property(i => i.Total)
               .IsRequired();

            builder.Property(i => i.VAT)
               .IsRequired();

            builder.HasOne(i => i.Customer)
               .WithMany(o => o.Orders);

            builder.HasOne(i => i.Category)
               .WithMany(o => o.Orders);

            builder.HasOne(i => i.User)
              .WithMany(o => o.Orders);

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

            builder.HasOne(i => i.Order)
                .WithMany(o => o.OrderProducts);

            builder.HasOne(i => i.Product)
                .WithMany(p => p.OrderProducts);

            builder.Property(i => i.Quantity)
                .IsRequired();

            builder.Property(i => i.CurrentProductPrice)
               .IsRequired();

            builder.Property(i => i.SubTotal)
               .IsRequired();

            builder.Property(i => i.TaxAmount)
               .IsRequired();

            builder.Property(i => i.Total)
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