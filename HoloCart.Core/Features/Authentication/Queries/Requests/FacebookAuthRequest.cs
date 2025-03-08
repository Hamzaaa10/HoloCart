using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Requests
{
    public class FacebookAuthRequest : IRequest<string>
    {
        public string RedirectUri { get; set; }
    }
}

