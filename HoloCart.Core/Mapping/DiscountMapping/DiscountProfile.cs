using AutoMapper;

namespace HoloCart.Core.Mapping.DiscountMapping
{
    public partial class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateDiscountMapping();
            UpdateDiscountMapping();
            GetDiscountByIdMapping();
            GetAllDiscountsMapping();

        }
    }
}
