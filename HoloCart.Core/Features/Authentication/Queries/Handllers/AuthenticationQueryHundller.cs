using HoloCart.Core.Bases;
using HoloCart.Core.Features.Authentication.Queries.Requests;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Handllers
{
    public class AuthenticationQueryHandler : ResponseHandller,
      IRequestHandler<AuthorizeUserRequest, Response<string>>,
      IRequestHandler<ConfirmEmailRequest, Response<string>>,
      IRequestHandler<ConfirmResetPasswordRequest, Response<string>>



    {

        private readonly IAuthenticationService _authenticationService;
        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }



        public async Task<Response<string>> Handle(AuthorizeUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ValidateToken(request.AccessToken);
            if (result == "NotExpired")
                return Success(result);
            return Unauthorized<string>();
        }

        public async Task<Response<string>> Handle(ConfirmEmailRequest request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationService.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("ErrorWhenConfirmEmail");
            return Success<string>("ConfirmEmailDone");
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmResetPassword(request.Email, request.Code);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserIsNotFound");
                case "Failed": return BadRequest<string>("InvaildCode");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("InvaildCode");
            }
        }
    }
}
