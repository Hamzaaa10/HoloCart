using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class UserConfigration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {

            // Primary Key
            builder.HasKey(u => u.Id);

            // One-to-Many: User -> Favorites
            builder.HasMany(u => u.Favorites)
                  .WithOne(f => f.user)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // One-to-One: User -> Carts
            builder.HasOne(u => u.Cart)
              .WithOne(c => c.user)
              .HasForeignKey<Cart>(c => c.UserId)
              .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: User -> Orders
            /* builder.HasMany(u => u.Orders)
               .WithOne(o => o.user)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Cascade);*/

            // One-to-Many: User -> ShippingAddresses
            builder.HasMany(u => u.ShippingAddresses)
              .WithOne(sa => sa.user)
              .HasForeignKey(sa => sa.UserId)
              .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
