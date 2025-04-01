using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductImageFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ProductImageFeatures.Query.Requests
{
    public class GetProductImageByIdQuery : IRequest<Response<GetProductImageByIdResponse>>
    {
        public int ProductImageId { get; set; }
        public GetProductImageByIdQuery(int id)
        {
            ProductImageId = id;
        }
    }
}
