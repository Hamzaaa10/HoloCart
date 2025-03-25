using HoloCart.Core.Features.CartFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.CartMapping
{
    public partial class CartProfile
    {
        public void CreateCartMapping()
        {
            CreateMap<CreateCartCommand, Cart>().ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.UserId));

        }
    }
}