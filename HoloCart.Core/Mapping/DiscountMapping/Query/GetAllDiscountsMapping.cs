using HoloCart.Core.Features.DiscountsFeatures.Quiries.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.DiscountMapping
{
    public partial class DiscountProfile
    {
        public void GetAllDiscountsMapping()
        {
            CreateMap<Discount, GetAllDiscountsResponse>().ForMember(dest => dest.IsActive, opt => opt.Ignore()); ;

        }
    }
}
