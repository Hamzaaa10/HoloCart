using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.CartItemFeature.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.CartItemFeature.Command.Hundller
{
    public class CartItemCommandHundller : ResponseHandller,
                                    IRequestHandler<AddCartItemCommand, Response<string>>,
                                    IRequestHandler<UpdateCartItemCommand, Response<string>>,
                                    IRequestHandler<DeleteCartItemCommand, Response<string>>






    {
        private readonly IMapper _mapper;
        private readonly ICartItemService _cartItemService;

        public CartItemCommandHundller(IMapper mapper, ICartItemService cartItemService)
        {
            _mapper = mapper;
            _cartItemService = cartItemService;
        }

        public async Task<Response<string>> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            var MappedCartItem = _mapper.Map<CartItem>(request);
            var Result = await _cartItemService.AddCartItemAsync(MappedCartItem);
            if (Result == "Success") return Success<string>("CartItem add Successfully");
            else if (Result == "ProductisAlreadyinCart") return Success<string>("CartItem is in the cart already and updated Based on Quentity ");
            else return BadRequest<string>("AddFailed");
        }

        public async Task<Response<string>> Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
        {
            var OldCartItem = await _cartItemService.GetCartItemByIdAcync(request.CartItemId);
            if (OldCartItem == null) return NotFound<string>("CartItemNotFound");
            var MappedCartt = _mapper.Map(request, OldCartItem);
            var Result = await _cartItemService.UpdateCartItemAsync(MappedCartt);

            if (Result == "Success") return Success("Cart Updated Successfully");
            else return BadRequest<string>("Failed In Update Cart");
        }

        public async Task<Response<string>> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartItemService.RemoveCartItemAsync(request.CartItemId);
            switch (result)
            {
                case "NotFound": return NotFound<string>("CartItem Not Found");
                case "FailedInDeleted": return BadRequest<string>("Failed In Deleted CartItem");
                case "Success": return Success<string>(" CartItem Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
