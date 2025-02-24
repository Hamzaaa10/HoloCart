using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class PaymentConfigration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {

            // Primary Key
            builder.HasKey(p => p.Id);

            // One-to-One: Payment -> Order
            builder.HasOne(p => p.Order)
                  .WithOne(o => o.Payment)
                  .HasForeignKey<Payment>(p => p.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
