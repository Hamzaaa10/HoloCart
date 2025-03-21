using HoloCart.Core.Features.ShippingAddressFeatures.command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ShippingAddressMapping
{
    public partial class ShippingAddressProfile
    {

        public void CreateShippingAddressMapping()
        {
            CreateMap<CreateShippingAddressCommand, ShippingAddress>().ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
