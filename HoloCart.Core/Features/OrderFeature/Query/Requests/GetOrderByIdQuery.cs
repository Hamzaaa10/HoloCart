using HoloCart.Core.Bases;
using HoloCart.Core.Features.OrderFeature.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.OrderFeature.Query.Requests
{
    public class GetOrderByIdQuery : IRequest<Response<GetOrderByIdResponse>>
    {
        public int OrderId { get; set; }

        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}