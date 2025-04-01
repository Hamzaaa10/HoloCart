using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductColorFeature.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Query.Requests
{
    public class GetProductColorByIdQuery : IRequest<Response<GetProductColorByIdResponse>>
    {
        public int Id { get; set; }

        public GetProductColorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
