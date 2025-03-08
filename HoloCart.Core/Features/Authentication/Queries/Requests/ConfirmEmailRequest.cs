using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.Authentication.Queries.Requests
{
    public class ConfirmEmailRequest : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}