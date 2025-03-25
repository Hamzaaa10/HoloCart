using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class CartRepository : GenericRepositoryAsync<Cart>, ICartRepository
    {
        private readonly DbSet<Cart> _carts;

        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {

            _carts = dbContext.Set<Cart>();
        }
    }
}