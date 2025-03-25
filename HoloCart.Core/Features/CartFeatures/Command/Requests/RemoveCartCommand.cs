using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartFeatures.Command.Requests
{
    public class RemoveCartCommand : IRequest<Response<string>>
    {
        public int CartId { get; set; }
        public RemoveCartCommand(int id)
        {
            CartId = id;
        }
    }
}
