using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;

namespace HoloCart.Service.Implemintation
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<string> AddOrderItemAsync(OrderItem orderItem)
        {
            try
            {
                await _orderItemRepository.AddAsync(orderItem);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }
    }
}
