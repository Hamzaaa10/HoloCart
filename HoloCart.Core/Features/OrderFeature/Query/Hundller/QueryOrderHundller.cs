using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.OrderFeature.Query.Requests;
using HoloCart.Core.Features.OrderFeature.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.OrderFeature.Query.Hundller
{
    public class QueryOrderHundller : ResponseHandller,
                                                       IRequestHandler<GetOrderByIdQuery, Response<GetOrderByIdResponse>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public QueryOrderHundller(IOrderService orderService, IMapper mapper, ICartService cartService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _cartService = cartService;
        }

        public async Task<Response<GetOrderByIdResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var Order = await _orderService.GetOrderByIdAsync(request.OrderId);
            if (Order == null) return NotFound<GetOrderByIdResponse>("Order Not Found");
            var MappedOrder = _mapper.Map<GetOrderByIdResponse>(Order);
            return Success<GetOrderByIdResponse>(MappedOrder);
        }
    }
}
