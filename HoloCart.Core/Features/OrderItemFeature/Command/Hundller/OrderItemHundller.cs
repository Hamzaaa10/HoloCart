using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.OrderItemFeature.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.OrderItemFeature.Command.Hundller
{
    public class OrderItemHundller : ResponseHandller, IRequestHandler<CreateOrderItemCommand, Response<string>>

    {
        private readonly IOrderItemService _orderItemService;
        private readonly IMapper _mapper;

        public OrderItemHundller(IOrderItemService orderItemService, IMapper mapper)
        {
            _orderItemService = orderItemService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var MappedOrderItem = _mapper.Map<OrderItem>(request);
            var result = await _orderItemService.AddOrderItemAsync(MappedOrderItem);
            if (result == "Success") return Success("OrderItem Created successfully");
            else if (result == "FailedInAdd") return BadRequest<string>("Failed To Add OrderItem");
            return BadRequest<string>();
        }
    }
}