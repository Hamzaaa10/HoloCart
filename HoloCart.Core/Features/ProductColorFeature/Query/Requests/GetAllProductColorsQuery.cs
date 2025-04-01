using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductColorFeature.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Query.Requests
{
    public class GetAllProductColorsQuery : IRequest<Response<List<GetAllProductColorsResponse>>>
    {
        public int ProductId { get; set; }
        public GetAllProductColorsQuery(int id)
        {
            ProductId = id;
        }
    }
}
