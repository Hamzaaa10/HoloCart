using HoloCart.API.Base;
using HoloCart.Core.Features.DiscountsFeatures.Command.Requests;
using HoloCart.Core.Features.DiscountsFeatures.Quiries.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class DiscountController : AppControllerBase
    {
        [HttpGet(Router.DiscountRouting.GetAll)]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var Response = await Mediator.Send(new GetAllDiscountsQuery());
            return NewResult(Response);
        }
        [HttpGet(Router.DiscountRouting.GetById)]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var Response = await Mediator.Send(new GetDiscountByIdQuery(id));
            return NewResult(Response);
        }


        [HttpPost(Router.DiscountRouting.Create)]
        public async Task<IActionResult> CreateDiscount([FromForm] CreateDiscountCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.DiscountRouting.Update)]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpDelete(Router.DiscountRouting.Delete)]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Response = await Mediator.Send(new DeleteDiscountCommand(id));
            return NewResult(Response);
        }

    }
}
