using FluentValidation;
using HoloCart.Core.Features.DepartmentFeatures.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.DepartmentFeatures.Commands.Validations
{
    public class UpdateCategoryValidations : AbstractValidator<UpdateCategoryRequest>
    {
        private readonly ICategoryService _categoryService;

        public UpdateCategoryValidations(ICategoryService categoryService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _categoryService = categoryService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("CategoryName is requierd")
                                .NotNull().WithMessage("CategoryName can't be nulll");

            RuleFor(x => x.CategoryImage).NotEmpty().WithMessage("CategoryImage is requierd")
                                    .NotNull().WithMessage("CategoryImage can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.Name)
                  .MustAsync(async (model, key, CancellationToken) => !await _categoryService.IsCategoryNameExistsExcloud(key, model.id)).WithMessage("Category is already existes");
        }



    }
}
