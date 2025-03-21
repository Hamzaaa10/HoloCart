using HoloCart.Core.Bases;
using HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.Query.Requests
{
    public class GetAllShippingAddressQuery : IRequest<Response<List<GetAllShippingAddressResponse>>>
    {

    }
}
