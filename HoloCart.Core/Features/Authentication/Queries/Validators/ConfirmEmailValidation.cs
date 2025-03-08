using FluentValidation;
using HoloCart.Core.Features.Authentication.Queries.Requests;

namespace HoloCart.Core.Features.Authentication.Queries.Validators
{
    internal class ConfirmEmailValidation : AbstractValidator<ConfirmEmailRequest>
    {
        public ConfirmEmailValidation()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.Code).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}

