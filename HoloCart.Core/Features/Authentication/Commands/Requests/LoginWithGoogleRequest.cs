using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class LoginWithGoogleRequest : IRequest<Response<JwtAuthResponse>>
    {
        public string GoogleToken { get; set; }
    }
}