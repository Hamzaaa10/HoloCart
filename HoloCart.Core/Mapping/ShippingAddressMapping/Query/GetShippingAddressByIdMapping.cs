using HoloCart.Core.Features.ShippingAddressFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ShippingAddressMapping
{
    public partial class ShippingAddressProfile
    {
        public void GetShippingAddressByIdMapping()
        {
            CreateMap<ShippingAddress, GetShippingAddressByIdResponses>().ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUserId));

        }
    }
}
