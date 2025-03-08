using FluentValidation;
using HoloCart.Core.Features.Authentication.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.Authentication.Commands.Validations
{
    public class ResetPasswordValidations : AbstractValidator<ResetPasswordRequest>
    {
        private readonly IApplicationUserService _applicationUserService;

        public ResetPasswordValidations(IApplicationUserService applicationUserService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _applicationUserService = applicationUserService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
                                .NotNull().WithMessage("FullName can't be nulll").EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");

            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("confirmpassword must matches Password ");


        }
        public void ApplayCustomValidationrules()
        {



        }

    }
}
