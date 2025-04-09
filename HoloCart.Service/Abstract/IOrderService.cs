using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IOrderService
    {
        public Task<string> AddOrderAsync(Order order);
        public Task<string> DeleteOrderAsync(int id);
        public Task<Order> GetOrderByIdAsync(int id);


    }
}
