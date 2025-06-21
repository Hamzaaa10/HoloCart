using HoloCart.API.Base;
using HoloCart.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class PaymentController : AppControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-or-update-intent/{userId}")]
        public async Task<IActionResult> CreateOrUpdateIntent(int userId)
        {
            var intent = await _paymentService.CreateOrUpdatePaymentIntent(userId);
            if (intent == null)
                return BadRequest("Cart is empty or user not found");

            return Ok(new
            {
                PaymentIntentId = intent.Id,
                ClientSecret = intent.ClientSecret
            });
        }
    }
}
