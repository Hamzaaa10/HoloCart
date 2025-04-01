using HoloCart.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Core.Features.ProductImageFeatures.Command.Requests
{
    public class CreateProductImageCommand : IRequest<Response<string>>
    {
        public int ProductColorId { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}