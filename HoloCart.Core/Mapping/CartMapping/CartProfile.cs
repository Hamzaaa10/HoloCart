using AutoMapper;

namespace HoloCart.Core.Mapping.CartMapping
{
    public partial class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateCartMapping();
            GetCartByUserIdMapping();
        }
    }
}
