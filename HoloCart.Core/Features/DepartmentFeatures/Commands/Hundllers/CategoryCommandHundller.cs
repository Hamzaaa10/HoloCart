using AutoMapper;
using HoloCart.Core.Bases;
using HoloCart.Core.Features.DepartmentFeatures.Commands.Requests;
using HoloCart.Data.Entities;
using HoloCart.Infrastructure.AbstractRepository;
using HoloCart.Service.Abstract;
using MediatR;

namespace HoloCart.Core.Features.DepartmentFeatures.Commands.Hundllers
{
    public class CategoryCommandHundller : ResponseHandller,
                                           IRequestHandler<AddCategoryRequest, Response<string>>,
                                           IRequestHandler<DeleteCategoryRequest, Response<string>>,
                                           IRequestHandler<UpdateCategoryRequest, Response<string>>




    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHundller(IMapper mapper, ICategoryService categoryService, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<string>> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
            var Category = _mapper.Map<Category>(request);
            var Result = await _categoryService.AddCategoryAsync(Category, request.CategoryImage);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInAdd": return BadRequest<string>("AddFailed");
            }
            return Success("Category Added Successufully");
        }

        public async Task<Response<string>> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var Result = await _categoryService.DeleteCategoryAsync(request.id);
            switch (Result)
            {
                case "Success": return Success<string>(" Deleted successfully");
                case "NotFound": return BadRequest<string>("NotFound");
                default: return BadRequest<string>(Result);
            }
        }

        public async Task<Response<string>> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            var Oldcategory = await _categoryRepository.GetByIdAsync(request.id);
            if (Oldcategory == null) return BadRequest<string>("CategoryNotFound");
            var NewCategory = _mapper.Map(request, Oldcategory);
            var Result = await _categoryService.UpdateCategoryAsync(request.id, NewCategory, request.CategoryImage);
            switch (Result)
            {
                case "NoImage": return BadRequest<string>("NoImage");
                case "FailedToUploadImage": return BadRequest<string>("FailedToUploadImage");
                case "FailedInUpdate": return BadRequest<string>("FailedInUpdate");
            }
            return Success("Category Updated Successufully");
        }
    }
}
