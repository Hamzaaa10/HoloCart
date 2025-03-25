using AutoMapper;

namespace HoloCart.Core.Mapping.OrderItemMapping
{
    public partial class OrderItemProfile : Profile
    {
        public OrderItemProfile()
        {
            CreateOrderItemMapping();
        }
    }
}
