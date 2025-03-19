using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ReviewFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Hundller
{
    public class ReviewHundller : ResponseHandller,
                                   IRequestHandler<CreateReviewCommnd, Response<string>>,
                                   IRequestHandler<UpdateReviewCommnd, Response<string>>,
                                   IRequestHandler<DeleteReviewCommnd, Response<string>>





    {


        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;


        public ReviewHundller(IMapper mapper, IReviewService reviewService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }

        public async Task<Response<string>> Handle(CreateReviewCommnd request, CancellationToken cancellationToken)
        {
            var MappedReview = _mapper.Map<Review>(request);
            var result = await _reviewService.AddReviewAsync(MappedReview);
            if (result == "Success") return Success("Created successfully");
            else if (result == "UserAlreadyReviewed") return BadRequest<string>("User Already ReviewedThis product");
            else if (result == "FailedInAdd") return BadRequest<string>("Failed In Add");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(UpdateReviewCommnd request, CancellationToken cancellationToken)
        {

            var OldReview = await _reviewService.GetReviewByIdAsync(request.ReviewId);
            if (OldReview == null) return NotFound<string>("Review Not Found");
            var MappedReview = _mapper.Map(request, OldReview);
            MappedReview.ReviewDate = DateTime.UtcNow;
            var Result = await _reviewService.UpdateReviewAsync(MappedReview);

            if (Result == "Success") return Success<string>("Review Updated Successfully");
            else return BadRequest<string>("Failed In Update");
        }

        public async Task<Response<string>> Handle(DeleteReviewCommnd request, CancellationToken cancellationToken)
        {
            var result = await _reviewService.DeleteReviewAsync(request.ReviewId);
            switch (result)
            {
                case "NotFound": return NotFound<string>("Discount Not Found");
                case "FailedInDeleted": return BadRequest<string>("FailedInDeleted");
                case "Success": return Success<string>("Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
