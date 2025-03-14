using HoloCart.API.Base;
using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;
using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class AplicationUserContoller : AppControllerBase
    {
        [HttpGet(Router.ApplicationUserRouting.GetByID)]
        public async Task<IActionResult> GetStudentListAsync(int id)
        {
            var Response = await Mediator.Send(new GetApplicationUserByIdRequest(id));
            return NewResult(Response);
        }

        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetApplicationUsersPaginatedRequest Query)
        {
            var Response = await Mediator.Send(Query);
            return Ok(Response);
        }
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAplicationUserRequest Command)
        {
            var response = await Mediator.Send(Command);
            return NewResult(response);
        }
        [HttpPut(Router.ApplicationUserRouting.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateAplicationUserRequest Command)
        {
            var response = await Mediator.Send(Command);
            return NewResult(response);
        }


        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromForm] ChangePasswordRequest command)
        {
            var Response = await Mediator.Send(command);
            return NewResult(Response);
        }

        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var Response = await Mediator.Send(new DeleteAplicationUserRequest(id));
            return NewResult(Response);
        }


    }
}

