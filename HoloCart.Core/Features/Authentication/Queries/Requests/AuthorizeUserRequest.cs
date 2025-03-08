using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Requests
{
    public class AuthorizeUserRequest : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }

}
