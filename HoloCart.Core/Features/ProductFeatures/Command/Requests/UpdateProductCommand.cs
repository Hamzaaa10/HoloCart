using HoloCart.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Core.Features.ProductFeatures.Command.Requests
{
    public class UpdateProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public IFormFile MainImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
    }
}
