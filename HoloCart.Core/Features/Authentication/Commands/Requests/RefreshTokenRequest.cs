using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class RefreshTokenRequest : IRequest<Response<JwtAuthResponse>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}