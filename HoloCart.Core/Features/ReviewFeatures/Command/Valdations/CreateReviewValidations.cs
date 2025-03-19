using FluentValidation;
using HoloCart.Core.Features.ReviewFeatures.Command.Requests;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Valdations
{
    public class CreateReviewValidations : AbstractValidator<CreateReviewCommnd>
    {

        public CreateReviewValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment is requierd")
                                .NotNull().WithMessage("Comment can't be nulll");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is requierd")
                               .NotNull().WithMessage("ProductId can't be nulll");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");
            RuleFor(x => x.Rating).NotEmpty().WithMessage("Rating is requierd")
                               .NotNull().WithMessage("Rating can't be nulll");







        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}