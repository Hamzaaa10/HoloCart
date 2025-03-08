using HoloCart.Data.Entities;
using HoloCart.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // Relationships
        builder.HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.ApplicationUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.ApplicationUserId);

        builder.HasMany(u => u.Reviews)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.ApplicationUserId);

        builder.HasMany(u => u.ShippingAddresses)
            .WithOne(sa => sa.User)
            .HasForeignKey(sa => sa.ApplicationUserId);

        builder.HasMany(u => u.UserRefreshTokens)
            .WithOne(urt => urt.applicationuser)
            .HasForeignKey(urt => urt.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Favourites)
            .WithOne(f => f.User)
            .HasForeignKey(f => f.ApplicationUserId);
    }
}