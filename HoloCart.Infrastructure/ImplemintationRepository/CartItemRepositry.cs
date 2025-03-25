using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class CartItemRepositry : GenericRepositoryAsync<CartItem>, ICartItemRepositry
    {
        private readonly DbSet<CartItem> _cartItems;

        public CartItemRepositry(AppDbContext dbContext) : base(dbContext)
        {
            _cartItems = dbContext.Set<CartItem>();
        }
    }
}