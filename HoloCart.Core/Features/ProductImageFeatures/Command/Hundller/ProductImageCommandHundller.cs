using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductImageFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductImageFeatures.Command.Hundller
{
    public class ProductImageCommandHundller : ResponseHandller, IRequestHandler<CreateProductImageCommand, Response<string>>
                                                               , IRequestHandler<UpdateProductImageCommand, Response<string>>
                                                               , IRequestHandler<DeleteProductImageCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageService _productImageService;

        public ProductImageCommandHundller(IMapper mapper, IProductImageService productImageService)
        {
            _mapper = mapper;
            _productImageService = productImageService;
        }
        public async Task<Response<string>> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var ProductImage = _mapper.Map<ProductImage>(request);
            var Result = await _productImageService.AddProductAsync(ProductImage, request.ImageUrl);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInAdd": return BadRequest<string>("AddFailed");
            }
            return Success("Product Added Successufully");
        }

        public async Task<Response<string>> Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var Result = await _productImageService.DeleteProductAsync(request.ProductImageId);
            switch (Result)
            {
                case "ProductImageNotFound": return BadRequest<string>("NotFound");
                case "FailedToDeleteImage": return BadRequest<string>("FailedToDeleteImage");
                case "Success": return Success<string>("Deleted successufly");
                default: return BadRequest<string>(Result);
            }
        }

        public async Task<Response<string>> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var OldProductImage = await _productImageService.GetProductImageById(request.ProductImageId);
            if (OldProductImage == null) return BadRequest<string>("ProductImage Not Found");
            var NewProductImage = _mapper.Map(request, OldProductImage);
            var Result = await _productImageService.UpdateProductAsync(request.ProductImageId, NewProductImage, request.ImageUrl);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInUpdate": return BadRequest<string>("FailedInUpdate");
            }
            return Success("Product Updated Successufully");
        }
    }
}
