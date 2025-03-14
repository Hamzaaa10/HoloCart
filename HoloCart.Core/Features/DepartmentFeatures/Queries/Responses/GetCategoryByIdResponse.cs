namespace HoloCart.Core.Features.DepartmentFeatures.Queries.Responses
{
    public class GetCategoryByIdResponse
    {
        public string CategoryImage { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }


    }
}
