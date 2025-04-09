using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.OrderFeature.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.OrderFeature.Command.Hundller
{
    public class OrderCommandHundller : ResponseHandller, IRequestHandler<CreateOrderCommand, Response<string>>
                                                        , IRequestHandler<DeleteOrderCommand, Response<string>>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public OrderCommandHundller(IOrderService orderService, IMapper mapper, ICartService cartService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _cartService = cartService;
        }
        public async Task<Response<string>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var cart = await _cartService.GetCartByUserIdAsync(request.UserId);
            if (cart == null || !cart.CartItems.Any())
            {
                return NotFound<string>("Cart is empty or not found.");
            }

            var order = _mapper.Map<Order>(cart);

            order.OrderDate = DateTime.UtcNow;
            order.ShippingAddressId = request.ShippingAddressId;
            var beforDisscountCopon = order.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity);
            order.TotalAmount = cart.DiscountCode != null ? beforDisscountCopon - (beforDisscountCopon * (cart.DiscountPercentage / 100)) : beforDisscountCopon;

            var createdOrder = await _orderService.AddOrderAsync(order);

            //  await _cartService.ClearCartAsync(request.UserId);

            if (createdOrder == "Success") return Success("Order Done Successfully");
            else return BadRequest<string>("Failed");
        }

        public async Task<Response<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var result = await _orderService.DeleteOrderAsync(request.OrderId);
            switch (result)
            {
                case "NotFound": return NotFound<string>("Order Not Found");
                case "FailedInDeleted": return BadRequest<string>("FailedInDeleted");
                case "Success": return Success<string>("Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
