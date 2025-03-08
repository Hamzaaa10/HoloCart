using FluentValidation;
using HoloCart.Core.Features.Authentication.Queries.Requests;

namespace HoloCart.Core.Features.Authentication.Queries.Validators
{
    public class ConfirmResetPasswordValidator : AbstractValidator<ConfirmResetPasswordRequest>
    {
        public ConfirmResetPasswordValidator()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}

