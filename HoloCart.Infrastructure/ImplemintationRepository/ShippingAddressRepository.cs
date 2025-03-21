using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class ShippingAddressRepository : GenericRepositoryAsync<ShippingAddress>, IShippingAddressRepository
    {
        private readonly DbSet<ShippingAddress> _shippingAddresses;

        public ShippingAddressRepository(AppDbContext dbContext) : base(dbContext)
        {

            _shippingAddresses = dbContext.Set<ShippingAddress>();
        }
    }
}
