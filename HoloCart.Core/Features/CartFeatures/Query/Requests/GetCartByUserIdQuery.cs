using HoloCart.Core.Bases;
using HoloCart.Core.Features.CartFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.CartFeatures.Query.Requests
{
    public class GetCartByUserIdQuery : IRequest<Response<GetCartByUserIdResponse>>
    {
        public int UserId { get; set; }
        public GetCartByUserIdQuery(int Id)
        {
            UserId = Id;
        }
    }
}
