using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.command.Requests
{
    public class CreateShippingAddressCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
