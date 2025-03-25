using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartItemFeature.Command.Requests
{
    public class DeleteCartItemCommand : IRequest<Response<string>>
    {
        public int CartItemId { get; set; }
        public DeleteCartItemCommand(int id)
        {
            CartItemId = id;
        }
    }
}
