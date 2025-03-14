using HoloCart.Core.Bases;
using HoloCart.Core.Features.DepartmentFeatures.Queries.Responses;
using MediatR;

namespace HoloCart.Core.Features.DepartmentFeatures.Queries.Requests
{
    public class GetCategoryByIdRequest : IRequest<Response<GetCategoryByIdResponse>>
    {
        public int Id { get; set; }
        public GetCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }
}
