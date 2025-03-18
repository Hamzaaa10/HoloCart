using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Query.Requests
{
    public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
