using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {


            builder.HasKey(oi => oi.Id);

            // Many-to-One: OrderItem -> Order
            builder.HasOne(oi => oi.Order)
                  .WithMany(o => o.OrderItems)
                  .HasForeignKey(oi => oi.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: OrderItem -> ProductVariant
            builder.HasOne(oi => oi.ProductVariant)
              .WithMany(pv => pv.OrderItems)
              .HasForeignKey(oi => oi.ProductVariantId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
