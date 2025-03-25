using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.PaymentFeature.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.PaymentFeature.Command.Hundller
{
    public class PaymentCommandHundller : ResponseHandller, IRequestHandler<CreatePaymentCommand, Response<string>>

    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentCommandHundller(IPaymentService PaymentService, IMapper mapper)
        {
            _paymentService = PaymentService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            //لسه هنا order id found/notfound
            var MappedPayment = _mapper.Map<Payment>(request);
            var result = await _paymentService.AddPaymentAsync(MappedPayment);
            if (result == "Success") return Success("Payment Created successfully");
            else if (result == "FailedInAdd") return BadRequest<string>("Failed In Add Payment");
            return BadRequest<string>();
        }
    }
}
