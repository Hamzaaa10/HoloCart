using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Requests
{
    public class UpdateReviewCommnd : IRequest<Response<string>>
    {
        public int ReviewId { get; set; }
        public UpdateReviewDto updateDto { get; set; }

        public UpdateReviewCommnd(int ReviewId, UpdateReviewDto updateDto)
        {
            this.ReviewId = ReviewId;
            this.updateDto = updateDto;
        }

        public class UpdateReviewDto
        {
            public int Rating { get; set; }
            public string Comment { get; set; }

            public UpdateReviewDto(string comment, int rating)
            {
                Rating = rating;
                Comment = comment;
            }
        }
    }
}