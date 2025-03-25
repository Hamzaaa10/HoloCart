using HoloCart.Core.Bases;
using HoloCart.Data.Enums.Payment;
using MediatR;

namespace HoloCart.Core.Features.PaymentFeature.Command.Requests
{
    public class CreatePaymentCommand : IRequest<Response<string>>
    {
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int OrderId { get; set; }
    }
}
