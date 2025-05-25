using HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ShippingAddressMapping
{
    public partial class ShippingAddressProfile
    {
        public void GetShippingAddressByUserIdMapping()
        {
            CreateMap<ShippingAddress, GetShippingAddressesByUserIdResponse>();

        }
    }
}
