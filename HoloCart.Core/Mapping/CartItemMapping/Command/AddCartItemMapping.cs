using HoloCart.Core.Features.CartItemFeature.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.CartItemMapping
{
    public partial class CartItemProfile
    {
        public void AddCartItemMapping()
        {
            CreateMap<AddCartItemCommand, CartItem>();

        }
    }
}
