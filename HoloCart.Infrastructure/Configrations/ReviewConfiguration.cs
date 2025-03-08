using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.ReviewId);

            builder.HasIndex(r => new { r.ApplicationUserId, r.ProductId })
                .IsUnique();

            builder.Property(r => r.Rating)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}