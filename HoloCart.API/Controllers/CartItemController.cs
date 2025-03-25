using HoloCart.API.Base;
using HoloCart.Core.Features.CartItemFeature.Command.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class CartItemController : AppControllerBase
    {
        [HttpPost(Router.CartItemRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddCartItemCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.CartItemRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCartItemCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpDelete(Router.CartItemRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteCartItemCommand(id));
            return NewResult(Response);
        }
    }
}
