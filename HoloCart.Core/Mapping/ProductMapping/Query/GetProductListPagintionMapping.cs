using HoloCart.Core.Features.ProductFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductMapping
{
    public partial class ProductProfile
    {
        public void GetProductListPagintionMapping()
        {
            CreateMap<Product, GetProductListPagintionResponse>()
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
               .ForMember(dest => dest.DiscountId, opt => opt.MapFrom(src => src.Discount.DiscountId))
               .ForMember(dest => dest.DiscountCode, opt => opt.MapFrom(src => src.Discount.Code))
               .ForMember(dest => dest.ModelUrl, opt => opt.MapFrom(src => src.Model))
               .ForMember(dest => dest.IsModel3D, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Model)))
               .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom(src => src.Discount.Percentage))
               .ForMember(dest => dest.FinalPrice, opt => opt.MapFrom(src =>
                src.Discount != null && DateTime.UtcNow >= src.Discount.StartDate && DateTime.UtcNow <= src.Discount.EndDate
                    ? src.BasePrice - (src.BasePrice * src.Discount.Percentage / 100)
                    : src.BasePrice
               ));

            CreateMap<Review, ReviewDto>()
                       .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));


        }
    }
}
