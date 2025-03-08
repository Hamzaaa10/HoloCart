using FluentValidation;
using HoloCart.Core.Features.Authentication.Commands.Requests;

namespace HoloCart.Core.Features.Authentication.Commands.Validations
{
    public class SigninValidations : AbstractValidator<SignInRequest>
    {
        public SigninValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Identifier).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}
