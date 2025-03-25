using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.OrderItemFeature.Command.Requests
{
    public class CreateOrderItemCommand : IRequest<Response<string>>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}