using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.DiscountsFeatures.Command.Requests
{
    public class UpdateDiscountCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
