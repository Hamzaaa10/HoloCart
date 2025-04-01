using FluentValidation;
using HoloCart.Core.Features.ApplicationUserFeatures.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.ApplicationUserFeatures.Commands.Validations
{
    public class UpdateAplicationUserValidation : AbstractValidator<UpdateAplicationUserRequest>
    {
        private readonly IApplicationUserService _applicationUserService;

        public UpdateAplicationUserValidation(IApplicationUserService applicationUserService)
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

            RuleFor(x => x.PhoneNumber).Length(11).WithMessage("phone numper must be 11 digts");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.UserName)
                   .MustAsync(async (model, key, CancellationToken) => !await _applicationUserService.IsUserNameExistsExcludeYourself(model.Id, key)).WithMessage("UserNamae Must be Unique ");




        }

    }
}

