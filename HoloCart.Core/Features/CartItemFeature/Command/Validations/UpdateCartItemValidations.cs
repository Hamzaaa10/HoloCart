using FluentValidation;
using HoloCart.Core.Features.CartItemFeature.Command.Requests;

namespace HoloCart.Core.Features.CartItemFeature.Command.Validations
{
    public class UpdateCartItemValidations : AbstractValidator<UpdateCartItemCommand>
    {


        public UpdateCartItemValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();

        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.CartItemId).NotEmpty().WithMessage("CartId is requierd")
                               .NotNull().WithMessage("CartId can't be nulll");

            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is requierd")
                                           .NotNull().WithMessage("Quantity can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {


        }
    }
}
