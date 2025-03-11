using HoloCart.API.Base;
using HoloCart.Core.Features.Authentication.Commands.Requests;
using HoloCart.Core.Features.Authentication.Queries.Requests;
using HoloCart.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace HoloCart.API.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        /*[HttpPost(Router.AuthenticationRouting.Register)]
        public async Task<IActionResult> Register([FromBody] AddAplicationUserRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }*/
        [HttpPost(Router.AuthenticationRouting.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpPost(Router.AuthenticationRouting.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenRequest Command)
        {
            var response = await Mediator.Send(Command);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationRouting.ValidateToken)]
        public async Task<IActionResult> ValidateToken([FromQuery] AuthorizeUserRequest Query)
        {
            var response = await Mediator.Send(Query);
            return NewResult(response);
        }
        [HttpGet(Router.AuthenticationRouting.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationRouting.SendResetPasswordCode)]
        public async Task<IActionResult> SendResetPasswordCode([FromForm] SendResetPasswordRequest Command)
        {
            var Response = await Mediator.Send(Command);
            return NewResult(Response);
        }
        [HttpGet(Router.AuthenticationRouting.ConfirmResetPasswordCode)]
        public async Task<IActionResult> ConfirmResetPassword([FromQuery] ConfirmResetPasswordRequest Query)
        {
            var response = await Mediator.Send(Query);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationRouting.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordRequest command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpPost(Router.AuthenticationRouting.GoogleLogin)]
        public async Task<IActionResult> LoginWithGoogle([FromBody] LoginWithGoogleRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpPost(Router.AuthenticationRouting.FacebookLogin)]
        public async Task<IActionResult> LoginWithFacebook([FromBody] LoginWithFacebookRequest request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
