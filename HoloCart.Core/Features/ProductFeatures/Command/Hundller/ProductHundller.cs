using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.ProductFeatures.Command.Requests;
using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Infrastructure.Hubs;
using HoloCart.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.SignalR;

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
        private readonly IHubContext<NotificationHub> _hubContext;


        public ProductHundller(IMapper mapper, IProductService productService, IProductRepository productRepository, IHubContext<NotificationHub> hubContext)
        {
            _mapper = mapper;
            _productService = productService;
            _productyRepository = productRepository;
            _hubContext = hubContext;
        }
        public async Task<Response<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var (status, createdProduct) = await _productService.AddProductAsync(product, request.MainImageUrl, request.Model);

            switch (status)
            {
                case "NoImage_Main": return BadRequest<string>("NoImage");
                case "FailedToUpload_Main": return BadRequest<string>("FailedToUploadImage");
                case "NoModel": return BadRequest<string>("NoModel");
                case "FailedToUpload_Model": return BadRequest<string>("FailedToUploadModel");
                case "FailedInAdd": return BadRequest<string>("AddFailed");
            }

            // ✅ Now we safely have the created product
            await _hubContext.Clients.All.SendAsync("NewProductCreated released", new
            {
                createdProduct!.ProductId,
                createdProduct.Name,
                createdProduct.BasePrice,
                createdProduct.Description,
                createdProduct.MainImageUrl,
                createdProduct.Model
            });

            return Success("Product Added Successfully");
        }



        public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var OldProduct = await _productService.GetByIdAcync(request.Id);
            if (OldProduct == null) return BadRequest<string>("Product Not Found");
            var NewProduct = _mapper.Map(request, OldProduct);
            var Result = await _productService.UpdateProductAsync(request.Id, NewProduct, request.MainImageUrl, request.Model);
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
                case "NotFound": return BadRequest<string>("NotFound");
                case "FailedToDeleteImage": return BadRequest<string>("NotFound");
                case "Success": return Success<string>(" Deleted successfully");
                default: return BadRequest<string>(Result);
            }
        }
    }
}
