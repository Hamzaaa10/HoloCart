using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authentication.Commands.Requests;
using HoloCart.Data.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Handllers
{
    public class AuthFacebookHandler : ResponseHandller, IRequestHandler<LoginWithFacebookRequest, Response<JwtAuthResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthFacebookHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Response<JwtAuthResponse>> Handle(LoginWithFacebookRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.LoginWithFacebook(request.FacebookToken);
            if (result == null)
                return BadRequest<JwtAuthResponse>("Invalid Facebook Token");

            return Success(result);
        }
    }

}

