using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartFeatures.Command.Requests
{
    public class CreateCartCommand : IRequest<Response<string>>
    {

        public int UserId { get; set; }

    }
}
