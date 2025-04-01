using AutoMapper;

namespace HoloCart.Core.Mapping.ProductImageMapping
{
    public partial class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateProductImageMapping();
            UpdateProductImageMapping();
            GetProductImageByIdMapping();
        }
    }
}
