using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ProductVariantConfigration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {

            // Primary Key
            builder.HasKey(pv => pv.Id);

            // One-to-Many: ProductVariant -> CartItems
            builder.HasMany(pv => pv.CartItems)
                  .WithOne(ci => ci.ProductVariant)
                  .HasForeignKey(ci => ci.ProductVariantId)
                  .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: ProductVariant -> OrderItems
            builder.HasMany(pv => pv.OrderItems)
              .WithOne(oi => oi.ProductVariant)
              .HasForeignKey(oi => oi.ProductVariantId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
