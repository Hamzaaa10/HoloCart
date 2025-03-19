using FluentValidation;
using HoloCart.Core.Features.ReviewFeatures.Command.Requests;

namespace HoloCart.Core.Features.ReviewFeatures.Command.Valdations
{
    public class UpdateReviewValidations : AbstractValidator<UpdateReviewCommnd>
    {

        public UpdateReviewValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.ReviewId).NotEmpty().WithMessage("Comment is requierd")
                                .NotNull().WithMessage("Comment can't be nulll");
            RuleFor(x => x.updateDto.Comment).NotEmpty().WithMessage("ProductId is requierd")
                               .NotNull().WithMessage("ProductId can't be nulll");
            RuleFor(x => x.updateDto.Rating).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");








        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}