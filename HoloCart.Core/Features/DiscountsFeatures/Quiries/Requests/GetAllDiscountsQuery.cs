using HoloCart.Core.Bases;
using HoloCart.Core.Features.DiscountsFeatures.Quiries.Responses;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Quiries.Requests
{
    public class GetAllDiscountsQuery : IRequest<Response<List<GetAllDiscountsResponse>>>
    {
    }
}
