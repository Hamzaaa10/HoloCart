using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.CartFeatures.Query.Requests;
using HoloCart.Core.Features.CartFeatures.Query.Responses;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Core.Features.CartFeatures.Query.Hundller
{
    public class CartQueryHundller : ResponseHandller,
                                    IRequestHandler<GetCartByUserIdQuery, Response<GetCartByUserIdResponse>>


    {
        private readonly IMapper _mapper;
        private readonly ICartService _carttService;
        private readonly IDiscountRepository _discountRepository;

        public CartQueryHundller(IMapper mapper, ICartService cartService, IDiscountRepository discountRepository)
        {
            _mapper = mapper;
            _carttService = cartService;
            _discountRepository = discountRepository;
        }

        public async Task<Response<GetCartByUserIdResponse>> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            var cart = await _carttService.GetCartByUserIdAsync(request.UserId);
            if (cart == null) return NotFound<GetCartByUserIdResponse>($"No Cart Found");

            decimal discountPercentage = 0;
            if (!string.IsNullOrEmpty(cart.DiscountCode))
            {
                var appliedDiscount = await _discountRepository.GetTableNoTracking()
                    .FirstOrDefaultAsync(d => d.Code == cart.DiscountCode &&
                                              d.StartDate <= DateTime.UtcNow &&
                                              d.EndDate >= DateTime.UtcNow);

                if (appliedDiscount != null)
                {
                    discountPercentage = appliedDiscount.Percentage;
                }
            }

            var mappedCart = _mapper.Map<GetCartByUserIdResponse>(cart, opt =>
            {
                opt.Items["DiscountPercentage"] = discountPercentage;
            });

            return Success(mappedCart);
        }
    }
}
