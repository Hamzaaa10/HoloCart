using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.DepartmentFeatures.Queries.Requests;
using HoloCart.Core.Features.DepartmentFeatures.Queries.Responses;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.DepartmentFeatures.Queries.Hundllers
{
    public class CategoryQueryHundller : ResponseHandller,
                                         IRequestHandler<GetCategoryByIdRequest, Response<GetCategoryByIdResponse>>,
                                         IRequestHandler<GetCategoriesRequest, Response<List<GetAllCategoriesResponse>>>

    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryQueryHundller(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<Response<GetCategoryByIdResponse>> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAcync(request.Id);
            if (category == null) return NotFound<GetCategoryByIdResponse>("Category Not Found");
            var MappedCategory = _mapper.Map<GetCategoryByIdResponse>(category);
            return Success(MappedCategory);
        }

        public async Task<Response<List<GetAllCategoriesResponse>>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetDepartmentsAcync();
            var MappedCategory = _mapper.Map<List<GetAllCategoriesResponse>>(categories);
            return Success(MappedCategory);
        }
    }
}
