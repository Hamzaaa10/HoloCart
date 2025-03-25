using HoloCart.Core.Features.DepartmentFeatures.Commands.Requests;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.CategoryMapping
{
    public partial class CategoryProfile
    {
        public void UpdateCategoryMapping()
        {
            CreateMap<UpdateCategoryRequest, Category>().ForMember(dest => dest.CategoryImage, opt => opt.Ignore());
        }
    }
}
