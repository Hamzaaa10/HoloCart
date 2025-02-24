using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class FavoriteConfigration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {

            // Primary Key
            builder.HasKey(f => f.Id);

            // Many-to-One: Favorite -> User
            builder.HasOne(f => f.user)
                  .WithMany(u => u.Favorites)
                  .HasForeignKey(f => f.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: Favorite -> Product
            builder.HasOne(f => f.Product)
                   .WithMany(p => p.Favorites)
                   .HasForeignKey(f => f.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Unique Constraint: UserId and ProductId
            builder.HasIndex(f => new
            {
                f.UserId,
                f.ProductId
            }).IsUnique();

        }
    }
}
