using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Query.Requests
{
    public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
    {

        public int ProductId { get; set; }
        public int UserId { get; set; }


    }
}
