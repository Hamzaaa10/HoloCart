using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class DiscountConfigration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);

            // Many-to-Many: Discount -> Products (via ProductDiscounts)
            builder.HasMany(d => d.ProductDiscounts)
                  .WithOne(pd => pd.Discount)
                  .HasForeignKey(pd => pd.DiscountId)
                  .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
