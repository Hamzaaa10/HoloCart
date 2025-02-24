using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ProductDiscountConfigration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {

            // Composite Primary Key
            builder.HasKey(pd => new
            {
                pd.ProductId,
                pd.DiscountId
            });

            // Many-to-One: ProductDiscount -> Product
            builder.HasOne(pd => pd.Product)
                  .WithMany(p => p.ProductDiscounts)
                  .HasForeignKey(pd => pd.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: ProductDiscount -> Discount
            builder.HasOne(pd => pd.Discount)
                  .WithMany(d => d.ProductDiscounts)
                  .HasForeignKey(pd => pd.DiscountId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
