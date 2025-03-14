using HoloCart.Core.Bases;
using MediatR;

namespace HoloCart.Core.Features.DepartmentFeatures.Commands.Requests
{
    public class DeleteCategoryRequest : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteCategoryRequest(int id)
        {
            this.id = id;
        }
    }
}
