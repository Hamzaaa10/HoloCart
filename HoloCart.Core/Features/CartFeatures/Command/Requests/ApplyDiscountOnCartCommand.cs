using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.CartFeatures.Command.Requests
{
    public class ApplyDiscountOnCartCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string DiscountCode { get; set; }
    }
}
