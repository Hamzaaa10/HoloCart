using HoloCart.Core.Features.OrderFeature.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.OrderMapping
{
    public partial class OrderProfile
    {

        public void GetOrderByIdMapping()
        {
            CreateMap<Order, GetOrderByIdResponse>()
           .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
           .ForMember(dest => dest.DiscountCode, opt => opt.MapFrom(src => src.User.Cart.DiscountCode))
             .ForMember(dest => dest.DiscountPercntage, opt => opt.MapFrom(src => src.User.Cart.DiscountPercentage));



            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
               .ForMember(dest => dest.ProductDiscount, opt => opt.MapFrom(src => src.Product.Discount.Percentage))
                ;


        }
    }
}
