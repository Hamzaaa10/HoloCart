using AutoMapper;

namespace HoloCart.Core.Mapping.ProductMapping
{
    public partial class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateProductMappimg();
            UpdateProductMappimg();
            GetProductByIdMapping();
            GetProductListPagintionMapping();
            GetProductsByCategoryMapping();
            GetAllProductsWithDiscountMapping();
        }
    }
}
