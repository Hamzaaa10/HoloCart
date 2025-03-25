using HoloCart.Core.Features.CartFeatures.Query.Responses;
using HoloCart.Data.Entities;
using static HoloCart.Core.Features.CartFeatures.Query.Responses.GetCartByUserIdResponse;

namespace HoloCart.Core.Mapping.CartMapping
{
    public partial class CartProfile
    {
        public void GetCartByUserIdMapping()
        {
            CreateMap<Cart, GetCartByUserIdResponse>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ApplicationUserId))
           .ForMember(dest => dest.DiscountCode, opt => opt.MapFrom(src => src.DiscountCode))
           .ForMember(dest => dest.DiscountPercentage, opt => opt.MapFrom((src, dest, _, context) =>
               context.Items.ContainsKey("DiscountPercentage") ? (decimal)context.Items["DiscountPercentage"] : 0))
           .ForMember(dest => dest.FinalTotal, opt => opt.MapFrom((src, dest, _, context) =>
           {
               decimal discountPercentage = context.Items.ContainsKey("DiscountPercentage") ? (decimal)context.Items["DiscountPercentage"] : 0;
               decimal cartTotal = dest.CartItems.Sum(item => item.TotalPrice);
               return cartTotal - (cartTotal * (discountPercentage / 100));
           }));

            CreateMap<CartItem, CartItemResponseDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Product.Description))
                .ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.Product.BasePrice))
                .ForMember(dest => dest.MainImageUrl, opt => opt.MapFrom(src => src.Product.MainImageUrl))
                .ForMember(dest => dest.DiscountedPrice, opt => opt.MapFrom(src =>
                    src.Product.Discount != null &&
                    DateTime.UtcNow >= src.Product.Discount.StartDate &&
                    DateTime.UtcNow <= src.Product.Discount.EndDate
                        ? src.Product.BasePrice - (src.Product.BasePrice * src.Product.Discount.Percentage / 100)
                        : src.Product.BasePrice))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src =>
                    (src.Product.Discount != null &&
                    DateTime.UtcNow >= src.Product.Discount.StartDate &&
                    DateTime.UtcNow <= src.Product.Discount.EndDate
                        ? src.Product.BasePrice - (src.Product.BasePrice * src.Product.Discount.Percentage / 100)
                        : src.Product.BasePrice) * src.Quantity));
        }
    }
}