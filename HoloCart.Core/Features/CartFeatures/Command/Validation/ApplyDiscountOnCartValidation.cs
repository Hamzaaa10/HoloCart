using FluentValidation;
using HoloCart.Core.Features.CartFeatures.Command.Requests;

namespace HoloCart.Core.Features.CartFeatures.Command.Validation
{
    public class ApplyDiscountOnCartValidation : AbstractValidator<ApplyDiscountOnCartCommand>
    {

        public ApplyDiscountOnCartValidation()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");
            RuleFor(x => x.DiscountCode).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");


        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}
