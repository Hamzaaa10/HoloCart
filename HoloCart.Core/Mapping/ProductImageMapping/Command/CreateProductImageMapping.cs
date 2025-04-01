using HoloCart.Core.Features.ProductImageFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductImageMapping
{
    public partial class ProductImageProfile
    {
        public void CreateProductImageMapping()
        {
            CreateMap<CreateProductImageCommand, ProductImage>();

        }
    }
}
