using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            // Primary Key
            builder.HasKey(p => p.Id);

            // One-to-Many: Product -> ProductVariants
            builder.HasMany(p => p.ProductVariants)
                  .WithOne(pv => pv.Product)
                  .HasForeignKey(pv => pv.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: Product -> Favorites
            builder.HasMany(p => p.Favorites)
              .WithOne(f => f.Product)
              .HasForeignKey(f => f.ProductId)
              .OnDelete(DeleteBehavior.Cascade);

            // Many-to-Many: Product -> Discounts (via ProductDiscounts)
            builder.HasMany(p => p.ProductDiscounts)
              .WithOne(pd => pd.Product)
              .HasForeignKey(pd => pd.ProductId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
