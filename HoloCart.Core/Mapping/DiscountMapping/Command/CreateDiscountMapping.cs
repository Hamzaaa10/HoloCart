using HoloCart.Core.Features.DiscountsFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.DiscountMapping
{
    public partial class DiscountProfile
    {

        public void CreateDiscountMapping()
        {
            CreateMap<CreateDiscountCommand, Discount>();
        }
    }
}
