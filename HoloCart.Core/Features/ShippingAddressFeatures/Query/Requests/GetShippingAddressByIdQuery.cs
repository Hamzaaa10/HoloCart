using HoloCart.Core.Bases;
using HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.Query.Requests
{
    public class GetShippingAddressByIdQuery : IRequest<Response<GetShippingAddressByIdResponses>>
    {
        public int Id { get; set; }
        public GetShippingAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
