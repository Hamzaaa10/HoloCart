using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.OrderMapping
{
    public partial class OrderProfile
    {
        public void CreateOrderMapping()
        {


            CreateMap<Cart, Order>()
           .ForMember(dest => dest.OrderId, opt => opt.Ignore())
           .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId))
           .ForMember(dest => dest.OrderDate, opt => opt.Ignore())
           .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
           .ForMember(dest => dest.ShippingAddressId, opt => opt.Ignore())
           .ForMember(dest => dest.DiscountId, opt => opt.Ignore())
           .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.CartItems));



            CreateMap<CartItem, OrderItem>()
    .ForMember(dest => dest.OrderItemId, opt => opt.Ignore())
    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
    .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src =>
                src.Product.Discount != null && DateTime.UtcNow >= src.Product.Discount.StartDate && DateTime.UtcNow <= src.Product.Discount.EndDate
                    ? src.Product.BasePrice - (src.Product.BasePrice * src.Product.Discount.Percentage / 100)
                    : src.Product.BasePrice))
    .ForMember(dest => dest.OrderId, opt => opt.Ignore());
        }


    }
}
