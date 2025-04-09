using HoloCart.API.Base;
using HoloCart.Core.Features.OrderFeature.Command.Requests;
using HoloCart.Core.Features.OrderFeature.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class OrderController : AppControllerBase
    {
        [HttpPost(Router.OrderRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }

        [HttpDelete(Router.OrderRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteOrderCommand(id));
            return Ok(Response);
        }
        [HttpGet(Router.OrderRouting.GetById)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var Response = await Mediator.Send(new GetOrderByIdQuery(id));
            return NewResult(Response);
        }
    }
}
