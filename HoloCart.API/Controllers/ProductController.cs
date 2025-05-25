using HoloCart.API.Base;
using HoloCart.Core.Features.ProductFeatures.Command.Requests;
using HoloCart.Core.Features.ProductFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace HoloCart.API.Controllers
{
    [ApiController]
    [EnableRateLimiting("ProductBrowsingPolicy")]

    public class ProductController : AppControllerBase
    {
        [HttpGet(Router.ProductRouting.PaginatedByDiscount)]
        public async Task<IActionResult> PaginatedByDiscount([FromQuery] GetAllProductsWithDiscountQuery query)
        {

            var Response = await Mediator.Send(query);
            return Ok(Response);
        }

        [HttpGet(Router.ProductRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetProductListPagintionQuery query)
        {

            var Response = await Mediator.Send(query);
            return Ok(Response);
        }
        [HttpGet(Router.ProductRouting.ProductsByCategory)]
        public async Task<IActionResult> PaginatedByCategory([FromQuery] GetProductsByCategoryQuery query)
        {

            var Response = await Mediator.Send(query);
            return Ok(Response);
        }
        [HttpGet(Router.ProductRouting.GetById)]
        public async Task<IActionResult> GetCategoryByIdAsync([FromQuery] GetProductByIdQuery query)
        {
            var Response = await Mediator.Send(query);
            return NewResult(Response);
        }
        [Authorize(Roles = "Admin")]

        [HttpPost(Router.ProductRouting.Create)]
        public async Task<IActionResult> Create([FromForm] CreateProductCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut(Router.ProductRouting.Update)]
        public async Task<IActionResult> Update([FromForm] UpdateProductCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete(Router.ProductRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteProductCommand(id));
            return Ok(Response);
        }

    }
}
