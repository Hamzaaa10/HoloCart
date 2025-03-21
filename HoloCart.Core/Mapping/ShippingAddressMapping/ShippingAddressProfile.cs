using AutoMapper;

namespace HoloCart.Core.Mapping.ShippingAddressMapping
{
    public partial class ShippingAddressProfile : Profile
    {
        public ShippingAddressProfile()
        {
            CreateShippingAddressMapping();
            UpdateShippingAddressMapping();
            GetAllShippingAddressMapping();
            GetShippingAddressByIdMapping();
        }
    }
}
