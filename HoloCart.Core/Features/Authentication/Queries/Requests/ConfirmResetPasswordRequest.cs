using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Requests
{
    public class ConfirmResetPasswordRequest : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
