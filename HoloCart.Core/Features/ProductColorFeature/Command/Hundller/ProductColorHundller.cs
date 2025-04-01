using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductColorFeature.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductColorFeature.Command.Hundller
{
    public class ProductColorHundller : ResponseHandller,
                                   IRequestHandler<CreateProductColorCommand, Response<string>>,
                                   IRequestHandler<UpdateProductColorCommand, Response<string>>,
                                   IRequestHandler<DeleteProductColorCommand, Response<string>>




    {


        private readonly IMapper _mapper;
        private readonly IProductColorService _productColorService;

        public ProductColorHundller(IMapper mapper, IProductColorService productColorService)
        {
            _mapper = mapper;
            _productColorService = productColorService;
        }

        public async Task<Response<string>> Handle(CreateProductColorCommand request, CancellationToken cancellationToken)
        {
            var productColor = _mapper.Map<ProductColor>(request);
            var Result = await _productColorService.AddProductColorAsync(productColor);

            if (Result == "Success") return Success<string>("ProductColor add Successfully");
            else return BadRequest<string>("AddFailed");

        }

        public async Task<Response<string>> Handle(UpdateProductColorCommand request, CancellationToken cancellationToken)
        {
            var OldProductColor = await _productColorService.GetProductColorById(request.ProductColorId);
            if (OldProductColor == null) return NotFound<string>("ProductColorNotFound");
            var MappedProductColor = _mapper.Map(request, OldProductColor);
            var Result = await _productColorService.UpdateProductColorAsync(MappedProductColor);

            if (Result == "Success") return Success<string>("ProductColor Updated Successfully");
            else return BadRequest<string>("Failed In Update");
        }

        public async Task<Response<string>> Handle(DeleteProductColorCommand request, CancellationToken cancellationToken)
        {
            var result = await _productColorService.DeleteProductColorAsync(request.ProductColorId);
            switch (result)
            {
                case "NotFound": return NotFound<string>("ProductColor Not Found");
                case "FailedInDeleted": return BadRequest<string>("FailedInDeleted");
                case "Success": return Success<string>("Deleted Successfully");

            }
            return BadRequest<string>();
        }
    }
}
