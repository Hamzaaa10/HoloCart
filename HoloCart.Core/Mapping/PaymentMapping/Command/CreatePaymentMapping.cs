using HoloCart.Core.Features.PaymentFeature.Command.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.PaymentMapping
{
    public partial class PaymentProfile
    {
        public void CreatePaymentMapping()
        {
            CreateMap<CreatePaymentCommand, Payment>().ForMember(dest => dest.PaymentDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        }
    }
}
