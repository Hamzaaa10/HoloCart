using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Requests
{
    public class CreateReviewCommnd : IRequest<Response<string>>
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
