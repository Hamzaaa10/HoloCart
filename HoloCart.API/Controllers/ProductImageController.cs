using HoloCart.API.Base;
using HoloCart.Core.Features.ProductImageFeatures.Command.Requests;
using HoloCart.Core.Features.ProductImageFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class ProductImageController : AppControllerBase
    {
        [HttpPost(Router.ProductImageRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreateProductImageCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.ProductImageRouting.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateProductImageCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpDelete(Router.ProductImageRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteProductImageCommand(id));
            return NewResult(Response);
        }
        [HttpGet(Router.ProductImageRouting.GetById)]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            var Response = await Mediator.Send(new GetProductImageByIdQuery(id));
            return NewResult(Response);
        }
    }
}
