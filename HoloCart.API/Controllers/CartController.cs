using HoloCart.API.Base;
using HoloCart.Core.Features.CartFeatures.Command.Requests;
using HoloCart.Core.Features.CartFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace HoloCart.API.Controllers
{
    [ApiController]
    [Authorize]
    [EnableRateLimiting("CartAndWishlistPolicy")]
    public class CartController : AppControllerBase
    {
        // [Authorize(Roles = "Admin")]
        [HttpPost(Router.CartRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreateCartCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpGet(Router.CartRouting.GetByUserId)]
        public async Task<IActionResult> GetCartByUserId(int id)
        {
            var Response = await Mediator.Send(new GetCartByUserIdQuery(id));
            return NewResult(Response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.CartRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new RemoveCartCommand(id));
            return NewResult(Response);
        }
        [HttpPut(Router.CartRouting.ApplayCode)]
        public async Task<IActionResult> ApplyDiscountCode([FromBody] ApplyDiscountOnCartCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
    }
}
