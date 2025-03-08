using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class ResetPasswordRequest : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
