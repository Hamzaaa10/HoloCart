using FluentValidation;
using HoloCart.Core.Features.CartFeatures.Command.Requests;

namespace HoloCart.Core.Features.CartFeatures.Command.Validation
{
    internal class RemoveCartValidation : AbstractValidator<RemoveCartCommand>
    {

        public RemoveCartValidation()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}


