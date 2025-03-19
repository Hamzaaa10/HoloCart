using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Requests
{
    public class DeleteReviewCommnd : IRequest<Response<string>>
    {
        public int ReviewId { get; set; }
        public DeleteReviewCommnd(int id)
        {
            ReviewId = id;
        }

    }
}
