using HoloCart.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Core.Features.ProductFeatures.Command.Requests
{
    public class CreateProductCommand : IRequest<Response<string>>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public IFormFile MainImageUrl { get; set; }
        public IFormFile? Model { get; set; }

        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }

    }
}
