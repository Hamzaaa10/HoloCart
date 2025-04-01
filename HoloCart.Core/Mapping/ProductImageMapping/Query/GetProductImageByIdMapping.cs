using HoloCart.Core.Features.ProductImageFeatures.Query.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductImageMapping
{
    public partial class ProductImageProfile
    {
        public void GetProductImageByIdMapping()
        {
            CreateMap<ProductImage, GetProductImageByIdResponse>();
        }
    }
}
