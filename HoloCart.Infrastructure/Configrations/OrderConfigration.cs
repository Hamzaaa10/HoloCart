using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {

            // Primary Key
            builder.HasKey(o => o.Id);

            // Many-to-One: Order -> User
            builder.HasOne(o => o.user)
                  .WithMany(u => u.Orders)
                  .HasForeignKey(o => o.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Many-to-One: Order -> ShippingAddress
            builder.HasOne(o => o.ShippingAddress)
              .WithMany(sa => sa.Orders)
              .HasForeignKey(o => o.ShippingAddressId)
              .OnDelete(DeleteBehavior.SetNull); // Set null on delete

            // One-to-Many: Order -> OrderItems
            builder.HasMany(o => o.OrderItems)
              .WithOne(oi => oi.Order)
              .HasForeignKey(oi => oi.OrderId)
              .OnDelete(DeleteBehavior.Cascade);

            // One-to-one: Order -> Payments
            builder.HasOne(o => o.Payment)
              .WithOne(p => p.Order)
              .HasForeignKey<Payment>(p => p.OrderId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
