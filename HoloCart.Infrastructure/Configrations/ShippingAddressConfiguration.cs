using HoloCart.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoloCart.Infrastructure.Configrations
{
    public class ShippingAddressConfig : IEntityTypeConfiguration<ShippingAddress>
    {
        public void Configure(EntityTypeBuilder<ShippingAddress> builder)
        {
            builder.HasKey(sa => sa.ShippingAddressId);
        }
    }
}