using HoloCart.Core.Bases;
using HoloCart.Core.Features.DiscountsFeatures.Quiries.Responses;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Quiries.Requests
{
    public class GetDiscountByIdQuery : IRequest<Response<GetDiscountByIdResponse>>
    {
        public int Id { get; set; }
        public GetDiscountByIdQuery(int id)
        {
            Id = id;
        }
    }
}
