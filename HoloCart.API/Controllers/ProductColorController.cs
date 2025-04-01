using HoloCart.API.Base;
using HoloCart.Core.Features.ProductColorFeature.Command.Requests;
using HoloCart.Core.Features.ProductColorFeature.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class ProductColorController : AppControllerBase
    {
        [HttpPost(Router.ProductColorRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateProductColorCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.ProductColorRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateProductColorCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpDelete(Router.ProductColorRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteProductColorCommand(id));
            return NewResult(Response);
        }
        [HttpGet(Router.ProductColorRouting.GetAll)]
        public async Task<IActionResult> GetAllProductColor(int id)
        {
            var Response = await Mediator.Send(new GetAllProductColorsQuery(id));
            return NewResult(Response);
        }
        [HttpGet(Router.ProductColorRouting.GetById)]
        public async Task<IActionResult> GetProductColorById(int id)
        {
            var Response = await Mediator.Send(new GetProductColorByIdQuery(id));
            return NewResult(Response);
        }
    }
}
