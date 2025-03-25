using HoloCart.API.Base;
using HoloCart.Core.Features.PaymentFeature.Command.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class PaymentController : AppControllerBase
    {
        [HttpPost(Router.PaymentRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreatePaymentCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
    }
}
