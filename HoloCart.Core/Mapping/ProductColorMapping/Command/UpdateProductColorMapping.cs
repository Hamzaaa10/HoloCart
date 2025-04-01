using HoloCart.Core.Features.ProductColorFeature.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.ProductColorMapping
{
    public partial class ProductColorProfile
    {
        public void UpdateProductColorMapping()
        {
            CreateMap<UpdateProductColorCommand, ProductColor>();

        }
    }
}
