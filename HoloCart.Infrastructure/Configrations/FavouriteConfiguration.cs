using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class FavouriteConfig : IEntityTypeConfiguration<Favourite>
    {
        public void Configure(EntityTypeBuilder<Favourite> builder)
        {
            builder.HasKey(f => f.FavouriteId);

            builder.HasIndex(f => new { f.ApplicationUserId, f.ProductId })
                .IsUnique();
        }
    }
}
