using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authentication.Commands.Requests;
using HoloCart.Data.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Handllers
{
    public class AuthGoogleHandler : ResponseHandller, IRequestHandler<LoginWithGoogleRequest, Response<JwtAuthResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthGoogleHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Response<JwtAuthResponse>> Handle(LoginWithGoogleRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.LoginWithGoogle(request.GoogleToken);

            if (result == null)
                return BadRequest<JwtAuthResponse>("Invalid Google Token or User creation failed");

            return Success(result);
        }

    }
}
