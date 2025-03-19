using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ReviewFeatures.Query.Requests;
using HoloCart.Core.Features.ReviewFeatures.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ReviewFeatures.Query.Hundller
{
    public class ReviewHundller : ResponseHandller,
                                    IRequestHandler<GetReviewsByProductQuery, Response<List<GetReviewsByProductResponse>>>



    {
        private readonly IMapper _mapper;
        private readonly IReviewService _reviewService;
        private readonly IProductService _productService;

        public ReviewHundller(IMapper mapper, IReviewService reviewService, IProductService productService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
            _productService = productService;
        }

        public async Task<Response<List<GetReviewsByProductResponse>>> Handle(GetReviewsByProductQuery request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetByIdAcync(request.ProductId);
            if (Product == null) return NotFound<List<GetReviewsByProductResponse>>("Product Not found");
            var Reviews = await _reviewService.GetAllReviewsWithProductAcync(request.ProductId);
            var result = _mapper.Map<List<GetReviewsByProductResponse>>(Reviews);
            return Success(result);
        }
    }
}
