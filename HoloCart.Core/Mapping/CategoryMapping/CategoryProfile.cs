using AutoMapper;

namespace HoloCart.Core.Mapping.CategoryMapping
{
    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            GetAllCategoriesMapping();
            AddCategoryMapping();
            GetCategoryByIdMapping();
            UpdateCategoryMapping();
        }
    }
}
