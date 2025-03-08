using FluentValidation;
using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Validations
{
    public class AddAplicationUserValidation : AbstractValidator<AddAplicationUserRequest>
    {
        private readonly IApplicationUserService _applicationUserService;

        public AddAplicationUserValidation(IApplicationUserService applicationUserService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _applicationUserService = applicationUserService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is requierd")
                                .MaximumLength(100).WithMessage("max leanth is 100 char").NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.FullName).NotEmpty().WithMessage("Fullname is requierd")
                                    .MaximumLength(100).WithMessage("max leanth is 200 char")
                                    .NotNull().WithMessage("FullName can't be nulll");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
                                .NotNull().WithMessage("FullName can't be nulll").EmailAddress();

            RuleFor(x => x.PhoneNumber).Length(11).WithMessage("phone numper must be 11 digts");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("confirmpassword must matches Password ");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.Email)
                   .MustAsync(async (key, CancellationToken) => !await _applicationUserService.IsEmailExists(key)).WithMessage("Email is already existes");
            RuleFor(x => x.UserName)
                   .MustAsync(async (key, CancellationToken) => !await _applicationUserService.IsUserNameExists(key)).WithMessage("UserNamae Must be Unique ");


        }

    }
}
