using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Bases;
using HoloCart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.ImplemintationRepository
{
    public class OrderRepository : GenericRepositoryAsync<Order>, IOrderRepository
    {
        private readonly DbSet<Order> _orders;

        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {

            _orders = dbContext.Set<Order>();
        }
    }
}
