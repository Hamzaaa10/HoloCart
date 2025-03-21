using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.ShippingAddressFeatures.command.Requests
{
    public class DeleteShippingAddressCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteShippingAddressCommand(int id)
        {
            Id = id;
        }
    }
}
