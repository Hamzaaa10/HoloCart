using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.DiscountsFeatures.Quiries.Requests;
using HoloCart.Core.Features.DiscountsFeatures.Quiries.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Quiries.Handller
{
    public class DiscountHundller : ResponseHandller,
                                    IRequestHandler<GetDiscountByIdQuery, Response<GetDiscountByIdResponse>>,
                                    IRequestHandler<GetAllDiscountsQuery, Response<List<GetAllDiscountsResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;

        public DiscountHundller(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            _discountService = discountService;
        }

        public async Task<Response<GetDiscountByIdResponse>> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
        {
            var Discount = await _discountService.GetDiscountById(request.Id);
            if (Discount == null) return NotFound<GetDiscountByIdResponse>("Discount Not Found");
            var MappedCategory = _mapper.Map<GetDiscountByIdResponse>(Discount);
            return Success<GetDiscountByIdResponse>(MappedCategory);
        }

        public async Task<Response<List<GetAllDiscountsResponse>>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var Discounts = await _discountService.GetAllDiscountsAcync();
            var result = _mapper.Map<List<GetAllDiscountsResponse>>(Discounts);
            return Success(result);
        }
    }
}
