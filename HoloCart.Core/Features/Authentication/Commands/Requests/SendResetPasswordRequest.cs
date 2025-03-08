using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class SendResetPasswordRequest : IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
