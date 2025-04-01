using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductColorFeature.Query.Requests;
using HoloCart.Core.Features.ProductColorFeature.Query.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Query.Hundller
{
    public class ProductColorHundller : ResponseHandller, IRequestHandler<GetAllProductColorsQuery, Response<List<GetAllProductColorsResponse>>>
                                                          , IRequestHandler<GetProductColorByIdQuery, Response<GetProductColorByIdResponse>>





    {


        private readonly IMapper _mapper;
        private readonly IProductColorService _productColorService;

        public ProductColorHundller(IMapper mapper, IProductColorService productColorService)
        {
            _mapper = mapper;
            _productColorService = productColorService;
        }

        public async Task<Response<List<GetAllProductColorsResponse>>> Handle(GetAllProductColorsQuery request, CancellationToken cancellationToken)
        {
            var ProductColors = await _productColorService.GetAllProductColorsAcync(request.ProductId);
            var result = _mapper.Map<List<GetAllProductColorsResponse>>(ProductColors);
            return Success(result);
        }

        public async Task<Response<GetProductColorByIdResponse>> Handle(GetProductColorByIdQuery request, CancellationToken cancellationToken)
        {
            var Productcolor = await _productColorService.GetProductColorById(request.Id);
            if (Productcolor == null) return NotFound<GetProductColorByIdResponse>("Product Color Not Found");
            var MappedProductColor = _mapper.Map<GetProductColorByIdResponse>(Productcolor);
            return Success(MappedProductColor);
        }
    }
}
