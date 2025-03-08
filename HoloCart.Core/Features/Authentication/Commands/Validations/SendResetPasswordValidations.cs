using FluentValidation;
using HoloCart.Core.Features.Authentication.Commands.Requests;

namespace HoloCart.Core.Features.Authentication.Commands.Validations
{
    public class SendResetPasswordValidations : AbstractValidator<SendResetPasswordRequest>
    {
        public SendResetPasswordValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}
