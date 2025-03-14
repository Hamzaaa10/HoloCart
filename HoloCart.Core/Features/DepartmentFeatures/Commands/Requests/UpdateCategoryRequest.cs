using HoloCart.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HoloCart.Core.Features.DepartmentFeatures.Commands.Requests
{
    public class UpdateCategoryRequest : IRequest<Response<string>>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile CategoryImage { get; set; }
        public int? ParentCategoryId { get; set; }

    }
}

