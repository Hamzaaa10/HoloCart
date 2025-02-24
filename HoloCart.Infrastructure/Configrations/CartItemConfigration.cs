using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class CartItemConfigration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {


            // Primary Key
            builder.HasKey(ci => ci.Id);

            // Many-to-One: CartItem -> Cart
            builder.HasOne(ci => ci.Cart)
              .WithMany(c => c.CartItems)
              .HasForeignKey(ci => ci.CartId)
              .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: CartItem -> ProductVariant
            builder.HasOne(ci => ci.ProductVariant)
              .WithMany(pv => pv.CartItems)
              .HasForeignKey(ci => ci.ProductVariantId)
              .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

