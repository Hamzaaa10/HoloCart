using FluentValidation;
using HoloCart.Core.Features.ProductFeatures.Command.Requests;

namespace HoloCart.Core.Features.ProductFeatures.Command.Validations
{
    internal class CreateProductValidations : AbstractValidator<CreateProductCommand>
    {

        public CreateProductValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is requierd")
                                .NotNull().WithMessage("Name can't be nulll");
            RuleFor(x => x.MainImageUrl).NotEmpty().WithMessage("MainImageUrl is requierd")
                               .NotNull().WithMessage("MainImageUrl can't be nulll");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("CategoryId is requierd")
                                .NotNull().WithMessage("CategoryId can't be nulll");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is requierd")
                               .NotNull().WithMessage("Description can't be nulll");
            RuleFor(x => x.BasePrice).NotEmpty().WithMessage("BasePrice is requierd")
                            .NotNull().WithMessage("BasePrice can't be nulll");






        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}
