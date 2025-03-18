using HoloCart.Core.Features.ProductFeatures.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductMapping
{
    public partial class ProductProfile
    {
        public void UpdateProductMappimg()
        {
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}