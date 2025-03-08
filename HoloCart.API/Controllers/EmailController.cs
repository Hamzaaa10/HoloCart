using HoloCart.API.Base;
using HoloCart.Core.Features.EmailFeatures.Commands.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{

    [ApiController]
    public class EmailController : AppControllerBase
    {
        [HttpPost(Router.EmailRouting.SendEmail)]

        /* [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
         [ProducesResponseType(StatusCodes.Status401Unauthorized)]
         [ProducesResponseType(StatusCodes.Status500InternalServerError)]
         [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> SendEmail([FromForm] SendEmailRequest Command)
        {
            var response = await Mediator.Send(Command);
            return NewResult(response);
        }
    }
}