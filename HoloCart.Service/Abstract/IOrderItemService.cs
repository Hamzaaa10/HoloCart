using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IOrderItemService
    {
        public Task<string> AddOrderItemAsync(OrderItem orderItem);

    }
}
