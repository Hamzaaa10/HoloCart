using HoloCart.Core.Bases;
using HoloCart.Core.Features.ReviewFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Query.Requests
{
    public class GetReviewsByProductQuery : IRequest<Response<List<GetReviewsByProductResponse>>>
    {
        public int ProductId { get; set; }
        public GetReviewsByProductQuery(int id)
        {
            ProductId = id;
        }
    }
}
