using HoloCart.API.Base;
using HoloCart.Core.Features.FavouriteFeatures.Command.Requests;
using HoloCart.Core.Features.FavouriteFeatures.Query.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace HoloCart.API.Controllers
{

    [ApiController]
    [Authorize]
    [EnableRateLimiting("CartAndWishlistPolicy")]
    public class FavouritController : AppControllerBase
    {

        [HttpGet(Router.FavouritRouting.GetAll)]
        public async Task<IActionResult> FavouritProducts(int id)
        {
            var Response = await Mediator.Send(new GetAllFavouritsQuery(id));
            return NewResult(Response);
        }


        [HttpPost(Router.FavouritRouting.Create)]
        public async Task<IActionResult> AddFavourit([FromBody] AddToFavouritesCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return Ok(Response);
        }

        [HttpDelete(Router.FavouritRouting.Delete)]
        public async Task<IActionResult> DeleteFavourit([FromBody] RemoveFavouriteCommand Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }

    }
}
