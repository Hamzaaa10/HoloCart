using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.ProductFeatures.Command.Hundller
{
    public class ProductHundller : ResponseHandller,
                                   IRequestHandler<CreateProductCommand, Response<string>>,
                                   IRequestHandler<UpdateProductCommand, Response<string>>,
                                   IRequestHandler<DeleteProductCommand, Response<string>>


    {


        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IProductRepository _productyRepository;

        public ProductHundller(IMapper mapper, IProductService productService, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productService = productService;
            _productyRepository = productRepository;
        }
        public async Task<Response<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var Product = _mapper.Map<Product>(request);
            var Result = await _productService.AddProductAsync(Product, request.MainImageUrl);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInAdd": return BadRequest<string>("AddFailed");
            }
            return Success("Product Added Successufully");
        }

        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var OldProduct = await _productService.GetByIdAcync(request.Id);
            if (OldProduct == null) return BadRequest<string>("Product Not Found");
            var NewProduct = _mapper.Map(request, OldProduct);
            var Result = await _productService.UpdateProductAsync(request.Id, NewProduct, request.MainImageUrl);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInUpdate": return BadRequest<string>("FailedInUpdate");
            }
            return Success("Product Updated Successufully");
        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var Result = await _productService.DeleteProductAsync(request.id);
            switch (Result)
            {
                case "Success": return Success<string>(" Deleted successfully");
                case "NotFound": return BadRequest<string>("NotFound");
                default: return BadRequest<string>(Result);
            }
        }
    }
}
