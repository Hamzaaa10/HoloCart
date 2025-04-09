using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Service.Implemintation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<string> AddOrderAsync(Order order)
        {
            try
            {
                await _orderRepository.AddAsync(order);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }

        public async Task<string> DeleteOrderAsync(int id)
        {
            var Order = await _orderRepository.GetByIdAsync(id);
            if (Order == null) return "NotFound";

            try
            {
                await _orderRepository.DeleteAsync(Order);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInDeleted";
            }
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetTableNoTracking().Include(u => u.User).ThenInclude(c => c.Cart)
               .Include(o => o.OrderItems).ThenInclude(o => o.Product)
            .ThenInclude(oi => oi.Discount)
               .FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}
