using Stripe;

namespace HoloCart.Service.Abstract
{
    public interface IPaymentService
    {
        Task<PaymentIntent?> CreateOrUpdatePaymentIntent(int userId);
        Task<PaymentIntent?> GetPaymentIntentByUserId(int userId);

    }
}
