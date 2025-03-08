using FluentValidation;
using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Validations
{
    public class ChangePasswordValidations : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {

            RuleFor(x => x.Id).NotEmpty().NotNull();

            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Password is requierd")
                                       .NotNull().WithMessage("Password can't be nulll");


            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("Password is requierd")
                                       .NotNull().WithMessage("Password can't be nulll");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.NewPassword).WithMessage("confirmpassword must matches NewPassword ").NotEmpty().WithMessage("ConfirmPassword is requierd")
                                       .NotNull().WithMessage("ConfirmPassword can't be nulll");


        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}


