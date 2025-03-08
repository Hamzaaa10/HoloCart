using FluentValidation;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.Authorization.Commands.Validations
{
    public class UpdateRoleValidations : AbstractValidator<AddRoleRequest>
    {
        private readonly IAuthorizationService _authorizationService;

        public UpdateRoleValidations(IAuthorizationService authorizationService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _authorizationService = authorizationService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName isrequierd")
                               .NotNull().WithMessage("RoleName Can't be null");

            RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName isrequierd")
                                .NotNull().WithMessage("RoleName Can't be null")
                                .MaximumLength(100).WithMessage("max leanth is 100 char");

        }
        public void ApplayCustomValidationrules()
        {



        }
    }
}


