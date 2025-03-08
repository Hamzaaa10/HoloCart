using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Requests
{

    public class GoogleAuthRequest : IRequest<string>
    {
        public string RedirectUri { get; set; }
    }
}