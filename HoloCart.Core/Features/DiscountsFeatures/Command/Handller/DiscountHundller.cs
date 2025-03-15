using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.DiscountsFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Command.Handller
{
    public class DiscountHundller : ResponseHandller,
                                    IRequestHandler<CreateDiscountCommand, Response<string>>,
                                    IRequestHandler<UpdateDiscountCommand, Response<string>>,
                                    IRequestHandler<DeleteDiscountCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly IDiscountService _discountService;

        public DiscountHundller(IMapper mapper, IDiscountService discountService)
        {
            _mapper = mapper;
            _discountService = discountService;
        }

        public async Task<Response<string>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var Discount = _mapper.Map<Discount>(request);
            var Result = await _discountService.AddDiscountAsync(Discount);

            if (Result == "Success") return Success<string>("Discount add Successfully");
            else return BadRequest<string>("AddFailed");

        }

        public async Task<Response<string>> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var OldDiscount = await _discountService.GetDiscountById(request.id);
            if (OldDiscount == null) return NotFound<string>("DiscountNotFound");
            var MappedDiscount = _mapper.Map(request, OldDiscount);
            var Result = await _discountService.UpdateDiscountAsync(MappedDiscount);

            if (Result == "Success") return Success<string>("Discount Updated Successfully");
            else return BadRequest<string>("Failed In Update");
        }

        public async Task<Response<string>> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var result = await _discountService.DeleteDiscountAsync(request.id);
            switch (result)
            {
                case "NotFound": return NotFound<string>("Discount Not Found");
                case "FailedInDeleted": return BadRequest<string>("FailedInDeleted");
                case "Success": return Success<string>("Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
