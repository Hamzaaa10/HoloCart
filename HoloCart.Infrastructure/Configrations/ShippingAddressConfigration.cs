using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ShippingAddressConfigration : IEntityTypeConfiguration<ShippingAddress>
    {
        public void Configure(EntityTypeBuilder<ShippingAddress> builder)
        {
            // Primary Key
            builder.HasKey(sa => sa.Id);

            // Many-to-One: ShippingAddress -> User
            builder.HasOne(sa => sa.user)
          .WithMany(u => u.ShippingAddresses)
          .HasForeignKey(sa => sa.UserId)
          .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: ShippingAddress -> Orders
            builder.HasMany(sa => sa.Orders)
          .WithOne(o => o.ShippingAddress)
          .HasForeignKey(o => o.ShippingAddressId)
          .OnDelete(DeleteBehavior.SetNull); // Set null on delete
        }
    }
}
