using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;

namespace HoloCart.Service.Implemintation
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<string> AddPaymentAsync(Payment payment)
        {
            try
            {
                await _paymentRepository.AddAsync(payment);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
        }
    }
}
