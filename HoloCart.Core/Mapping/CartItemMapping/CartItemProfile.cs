using AutoMapper;

namespace HoloCart.Core.Mapping.CartItemMapping
{
    public partial class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            AddCartItemMapping();
            UpdateCartItemMapping();
        }
    }
}
