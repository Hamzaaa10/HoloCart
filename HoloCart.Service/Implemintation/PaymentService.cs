using HoloCart.Data.Helpers;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using Microsoft.Extensions.Options;
using Stripe;

namespace HoloCart.Service.Implemintation
{

    public class PaymentService : IPaymentService
    {
        private readonly ICartService _cartservice;
        private readonly ICartRepository _cartRepository;

        private readonly StripeSettings _stripeSettings;

        public PaymentService(
            ICartService cartservice,
            ICartRepository cartRepository,
            IOptions<StripeSettings> stripeOptions)
        {
            _cartservice = cartservice;
            _cartRepository = cartRepository;
            _stripeSettings = stripeOptions.Value;

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }

        public async Task<PaymentIntent?> CreateOrUpdatePaymentIntent(int userId)
        {
            var cart = await _cartservice.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartItems.Any())
                return null;

            var total = cart.CartItems.Sum(item => item.Quantity * item.Product.BasePrice);
            if (cart.DiscountPercentage > 0)
            {
                total -= total * (cart.DiscountPercentage / 100.0m);
            }

            var amount = (long)(total * 100); // Stripe يتعامل بالسنت

            var service = new PaymentIntentService();
            PaymentIntent intent;

            if (!string.IsNullOrEmpty(cart.PaymentIntentId))
            {
                intent = await service.UpdateAsync(cart.PaymentIntentId, new PaymentIntentUpdateOptions
                {
                    Amount = amount
                });
            }
            else
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(options);
                cart.PaymentIntentId = intent.Id;
                await _cartRepository.UpdateAsync(cart);
            }

            return intent;
        }

        public async Task<PaymentIntent?> GetPaymentIntentByUserId(int userId)
        {
            var cart = await _cartservice.GetCartByUserIdAsync(userId);
            if (cart == null || string.IsNullOrEmpty(cart.PaymentIntentId))
                return null;

            var service = new PaymentIntentService();
            return await service.GetAsync(cart.PaymentIntentId);
        }


    }
}