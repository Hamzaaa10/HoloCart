using AutoMapper;

namespace HoloCart.Core.Mapping.ProductColorMapping
{
    public partial class ProductColorProfile : Profile
    {
        public ProductColorProfile()
        {
            CreateProductColorMapping();
            UpdateProductColorMapping();
            GetAllProductColorMapping();
            GetProductColorByIdMapping();
        }
    }
}
