using HoloCart.Core.Bases;
using HoloCart.Data.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HoloCart.Core.Features.Authentication.Commands.Requests
{
    public class SignInRequest : IRequest<Response<JwtAuthResponse>>
    {
        public string Identifier { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
