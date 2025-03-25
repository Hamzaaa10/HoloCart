using HoloCart.Core.Features.OrderItemFeature.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.OrderItemMapping
{
    public partial class OrderItemProfile
    {
        public void CreateOrderItemMapping()
        {
            CreateMap<CreateOrderItemCommand, OrderItem>();
        }
    }
}
