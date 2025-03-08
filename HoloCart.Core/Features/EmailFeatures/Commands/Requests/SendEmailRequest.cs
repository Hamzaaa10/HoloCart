using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.EmailFeatures.Commands.Requests
{
    public class SendEmailRequest : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Message { get; set; }
    }
}