using HoloCart.Core.Features.ApplicationUserFeatures.Queries.Responses;
using MediatR;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Queries.Requests
{
    public class GetApplicationUserByIdRequest : IRequest<Bases.Response<GetApplicationUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetApplicationUserByIdRequest(int id)
        {
            Id = id;
        }
    }
}
