using HoloCart.API.Base;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using HoloCart.Core.Features.Authorization.Queries.Requests;
using HoloCart.Core.Features.Authorization.Queries.Responses;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{

    [ApiController]
    public class AuthorizationController : AppControllerBase
    {
        [HttpGet(Router.AuthorizationRouting.GetAll)]
        public async Task<IActionResult> GetAllRolesAsync()
        {
            var Response = await Mediator.Send(new GetAllRolesRequest());
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRouting.GetById)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var Response = await Mediator.Send(new GetRoleByIdRequest(id));
            return NewResult(Response);
        }
        [HttpPost(Router.AuthorizationRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRouting.Update)]

        public async Task<IActionResult> Update([FromForm] UpdateRoleRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpDelete(Router.AuthorizationRouting.Delete)]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Response = await Mediator.Send(new DeleteRoleRequest(id));
            return NewResult(Response);
        }
        [HttpGet(Router.AuthorizationRouting.ManageUserRole)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int id)
        {
            var Response = await Mediator.Send(new ManageUserRoleRequest(id));
            return NewResult(Response);
        }

        [HttpPut(Router.AuthorizationRouting.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserClaimRequest command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.AuthorizationRouting.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int id)
        {
            var Response = await Mediator.Send(new ManageUserClaimsRequest(id));
            return NewResult(Response);
        }
        [HttpPut(Router.AuthorizationRouting.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimRequest command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
