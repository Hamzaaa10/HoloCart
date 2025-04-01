using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductImageFeatures.Query.Requests;
using HoloCart.Core.Features.ProductImageFeatures.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductImageFeatures.Query.Hundller
{
    public class ProductImageQueryHundller : ResponseHandller, IRequestHandler<GetProductImageByIdQuery, Response<GetProductImageByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageService _productImageService;

        public ProductImageQueryHundller(IMapper mapper, IProductImageService productImageService)
        {
            _mapper = mapper;
            _productImageService = productImageService;
        }

        public async Task<Response<GetProductImageByIdResponse>> Handle(GetProductImageByIdQuery request, CancellationToken cancellationToken)
        {
            var ProductImage = await _productImageService.GetProductImageById(request.ProductImageId);
            if (ProductImage == null) return NotFound<GetProductImageByIdResponse>("Product Color Not Found");
            var MappedProductColor = _mapper.Map<GetProductImageByIdResponse>(ProductImage);
            return Success(MappedProductColor);
        }
    }
}
