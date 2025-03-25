using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class OrderItemRepository : GenericRepositoryAsync<OrderItem>, IOrderItemRepository
    {
        private readonly DbSet<OrderItem> _orderItemes;

        public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
        {

            _orderItemes = dbContext.Set<OrderItem>();
        }
    }
}


