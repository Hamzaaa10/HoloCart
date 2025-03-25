using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.CartFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.CartFeatures.Command.Hundller
{
    public class CartCommandHundller : ResponseHandller,
                                    IRequestHandler<CreateCartCommand, Response<string>>,
                                    IRequestHandler<RemoveCartCommand, Response<string>>,
                                    IRequestHandler<ApplyDiscountOnCartCommand, Response<string>>




    {
        private readonly IMapper _mapper;
        private readonly ICartService _carttService;

        public CartCommandHundller(IMapper mapper, ICartService cartService)
        {
            _mapper = mapper;
            _carttService = cartService;
        }

        public async Task<Response<string>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var MappedCart = _mapper.Map<Cart>(request);
            var result = await _carttService.CreateCartAsync(MappedCart);
            if (result == "Success") return Success(" Cart Created successfully");
            else if (result == "UserAlreadyHaveCart") return BadRequest<string>("User Already Have a Cart ");
            else if (result == "FailedInAdd") return BadRequest<string>("Failed In Add cart");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(RemoveCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _carttService.RemoveCartAsync(request.CartId);
            switch (result)
            {
                case "NotFound": return NotFound<string>("Cart Not Found");
                case "FailedInDeleted": return BadRequest<string>("Failed In Deleted Cart");
                case "Success": return Success<string>(" Cart Deleted Successfully");

            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(ApplyDiscountOnCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _carttService.ApplyDiscountOnCartValidation(request.UserId, request.DiscountCode);
            switch (result)
            {
                case "NotFound": return NotFound<string>("Cart with this id was Not Found");
                case "CodeIsNotValid": return BadRequest<string>("Code Is Not Valid");
                case "Success": return Success<string>(" Code applyed successfully");

            }
            return BadRequest<string>();
        }
    }
}
