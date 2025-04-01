using HoloCart.Core.Features.ProductColorFeature.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductColorMapping
{
    public partial class ProductColorProfile
    {
        public void GetProductColorByIdMapping()
        {
            CreateMap<ProductColor, GetProductColorByIdResponse>()
           .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<ProductImage, ProductImageResponseDto>();
        }
    }
}
