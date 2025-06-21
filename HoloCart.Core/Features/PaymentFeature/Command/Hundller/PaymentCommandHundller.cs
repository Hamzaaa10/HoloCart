using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.PaymentFeature.Command.Hundller
{
    public class PaymentCommandHundller : ResponseHandller

    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentCommandHundller(IPaymentService PaymentService, IMapper mapper)
        {
            _paymentService = PaymentService;
            _mapper = mapper;
        }


    }
}
