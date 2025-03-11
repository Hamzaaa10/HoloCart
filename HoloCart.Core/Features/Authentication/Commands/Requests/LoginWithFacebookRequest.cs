using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class LoginWithFacebookRequest : IRequest<Response<JwtAuthResponse>>
    {
        public string FacebookToken { get; set; }
    }
}