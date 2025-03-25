using AutoMapper;

namespace HoloCart.Core.Mapping.PaymentMapping
{
    public partial class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreatePaymentMapping();
        }
    }
}
