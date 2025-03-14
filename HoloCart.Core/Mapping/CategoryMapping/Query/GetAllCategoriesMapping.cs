using HoloCart.Core.Features.DepartmentFeatures.Queries.Responses;
using HoloCart.Data.Entities;

namespace HoloCart.Core.Mapping.CategoryMapping
{
    public partial class CategoryProfile
    {

        public void GetAllCategoriesMapping()
        {
            CreateMap<Category, GetAllCategoriesResponse>();
            ;
        }
    }
}
