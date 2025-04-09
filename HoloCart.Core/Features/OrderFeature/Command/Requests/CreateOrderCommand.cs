using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.OrderFeature.Command.Requests
{
    public class CreateOrderCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public int ShippingAddressId { get; set; }
        public int? DiscountId { get; set; }

    }

}