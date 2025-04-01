using HoloCart.Core.Features.ProductColorFeature.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductColorMapping
{
    public partial class ProductColorProfile
    {
        public void GetAllProductColorMapping()
        {
            CreateMap<ProductColor, GetAllProductColorsResponse>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<ProductImage, ProductImageResponseDto>();

        }
    }
}
