using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ProductColorConfig : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.HasKey(pc => pc.ProductColorId);

            builder.HasOne(pc => pc.Image)
                .WithOne(pi => pi.ProductColor)
                .HasForeignKey<ProductColor>(pc => pc.ProductImageId)
                .IsRequired();
            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.Colors) // A Product has many Colors
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete if needed
        }
    }
}