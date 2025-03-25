using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartItemFeature.Command.Requests
{
    public class UpdateCartItemCommand : IRequest<Response<string>>
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }

    }
}
