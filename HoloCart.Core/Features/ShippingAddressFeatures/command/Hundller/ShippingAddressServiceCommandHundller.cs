using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ShippingAddressFeatures.command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.command.Hundller
{
    public class ShippingAddressServiceCommandHundller : ResponseHandller,
                                   IRequestHandler<CreateShippingAddressCommand, Response<string>>,
                                   IRequestHandler<UpdateShippingAddressCommand, Response<string>>,
                                   IRequestHandler<DeleteShippingAddressCommand, Response<string>>

    {


        private readonly IMapper _mapper;
        private readonly IShippingAddressService _shippingAddressService;
        public ShippingAddressServiceCommandHundller(IShippingAddressService shippingAddressService, IMapper mapper)
        {
            _mapper = mapper;
            _shippingAddressService = shippingAddressService;
        }

        public async Task<Response<string>> Handle(UpdateShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var OldShippingAddress = await _shippingAddressService.GetShippingAddressById(request.Id);
            if (OldShippingAddress == null) return NotFound<string>("Shipping Adrdees Not Found");
            var MappedShippingAddress = _mapper.Map(request, OldShippingAddress);
            var Result = await _shippingAddressService.UpdateShippingAddressAsync(MappedShippingAddress);

            if (Result == "Success") return Success<string>("ShippingAddress Updated Successfully");
            else return BadRequest<string>("Failed In Update ShippingAddress");
        }

        public async Task<Response<string>> Handle(DeleteShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var result = await _shippingAddressService.DeleteShippingAddressAsync(request.Id);
            switch (result)
            {
                case "NotFound": return NotFound<string>("ShippingAddress Not Found");
                case "FailedInDeleted": return BadRequest<string>("Failed In Deleted ShippingAddress");
                case "Success": return Success<string>("ShippingAddress Deleted Successfully");

            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(CreateShippingAddressCommand request, CancellationToken cancellationToken)
        {
            var MappedShipping = _mapper.Map<ShippingAddress>(request);
            var result = await _shippingAddressService.AddShippingAddressAsync(MappedShipping);
            if (result == "Success") return Success("ShippingAddress Created successfully");
            else if (result == "FailedInAdd") return BadRequest<string>("Failed In Add ShippingAddress");
            return BadRequest<string>();
        }
    }
}

