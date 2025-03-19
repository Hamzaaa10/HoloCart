using HoloCart.API.Base;
using HoloCart.Core.Features.ReviewFeatures.Command.Requests;
using HoloCart.Core.Features.ReviewFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using static HoloCart.Core.Features.ReviewFeatures.Command.Requests.UpdateReviewCommnd;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class ReviewController : AppControllerBase
    {
        [HttpGet(Router.ReviewRouting.ReviewsWithProduct)]
        public async Task<IActionResult> GetReviewsWithProduct(int id)
        {
            var Response = await Mediator.Send(new GetReviewsByProductQuery(id));
            return NewResult(Response);
        }
        [HttpPost(Router.ReviewRouting.Create)]
        public async Task<IActionResult> Create([FromBody] CreateReviewCommnd Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }
        [HttpPut(Router.ReviewRouting.Update)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateReviewDto Command)
        {
            var Response = await Mediator.Send(new UpdateReviewCommnd(id, Command));
            return Ok(Response);
        }
        [HttpDelete(Router.ReviewRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteReviewCommnd(id));
            return NewResult(Response);
        }
    }
}
