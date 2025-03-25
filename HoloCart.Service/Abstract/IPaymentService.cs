using HoloCart.Data.Entities;

namespace HoloCart.Service.Abstract
{
    public interface IPaymentService
    {
        public Task<string> AddPaymentAsync(Payment payment);

    }
}
