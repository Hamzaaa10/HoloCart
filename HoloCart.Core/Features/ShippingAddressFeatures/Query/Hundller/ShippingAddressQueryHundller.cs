using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ShippingAddressFeatures.Query.Requests;
using HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.Query.Hundller
{
    internal class ShippingAddressQueryHundller : ResponseHandller,
                                   IRequestHandler<GetAllShippingAddressQuery, Response<List<GetAllShippingAddressResponse>>>,
                                   IRequestHandler<GetShippingAddressByIdQuery, Response<GetShippingAddressByIdResponses>>,
                                  IRequestHandler<GetShippingAddressesByUserIdQuery, Response<List<GetShippingAddressesByUserIdResponse>>>




    {


        private readonly IMapper _mapper;
        private readonly IShippingAddressService _shippingAddressService;
        public ShippingAddressQueryHundller(IShippingAddressService shippingAddressService, IMapper mapper)
        {
            _mapper = mapper;
            _shippingAddressService = shippingAddressService;
        }

        public async Task<Response<List<GetAllShippingAddressResponse>>> Handle(GetAllShippingAddressQuery request, CancellationToken cancellationToken)
        {
            var ShippingAddresses = await _shippingAddressService.GetAllShippingAddressAcync();
            if (ShippingAddresses.Count() < 1) return NotFound<List<GetAllShippingAddressResponse>>("No ShippingAddresses Created yet");
            var MappedShippingAddresses = _mapper.Map<List<GetAllShippingAddressResponse>>(ShippingAddresses);
            return Success(MappedShippingAddresses);
        }

        public async Task<Response<GetShippingAddressByIdResponses>> Handle(GetShippingAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var ShippingAddresses = await _shippingAddressService.GetShippingAddressById(request.Id);
            if (ShippingAddresses == null) return NotFound<GetShippingAddressByIdResponses>("ShippingAddresses Not Found");
            var MappedShippingAddresses = _mapper.Map<GetShippingAddressByIdResponses>(ShippingAddresses);
            return Success(MappedShippingAddresses);
        }

        public async Task<Response<List<GetShippingAddressesByUserIdResponse>>> Handle(GetShippingAddressesByUserIdQuery request, CancellationToken cancellationToken)
        {

            var ShippingAddresses = await _shippingAddressService.GetShippingAddressesByUserId(request.UserId);
            if (ShippingAddresses == null) return NotFound<List<GetShippingAddressesByUserIdResponse>>("UserNot found");
            if (ShippingAddresses.Count() < 1) return NotFound<List<GetShippingAddressesByUserIdResponse>>("No ShippingAddresses Created yet");
            var MappedShippingAddresses = _mapper.Map<List<GetShippingAddressesByUserIdResponse>>(ShippingAddresses);
            return Success(MappedShippingAddresses);
        }
    }
}