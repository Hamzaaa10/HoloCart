using AutoMapper;

namespace HoloCart.Core.Mapping.OrderMapping
{
    public partial class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateOrderMapping();
            GetOrderByIdMapping();
        }
    }
}
