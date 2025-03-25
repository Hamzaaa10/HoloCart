using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartItemFeature.Command.Requests
{
    public class AddCartItemCommand : IRequest<Response<string>>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
