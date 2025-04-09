using HoloCart.API.Base;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class OrderItemController : AppControllerBase
    {
        /* [HttpPost(Router.OrderItemRouting.Create)]
         public async Task<IActionResult> Create([FromForm] CreateOrderItemCommand Command)
         {
             var Response = await Mediator.Send(Command);
             return Ok(Response);
         }*/
    }
}
