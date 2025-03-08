using FluentValidation;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using IAuthorizationService = HoloCart.Service.Abstract.IAuthorizationService;

namespace HoloCart.Core.Features.Authorization.Commands.Validations
{
    public class AddRoleValidations : AbstractValidator<AddRoleRequest>
    {
        private readonly IAuthorizationService _authorizationService;

        public AddRoleValidations(IAuthorizationService authorizationService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _authorizationService = authorizationService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName isrequierd")
                                .NotNull().WithMessage("RoleName Can't be null")
                                .MaximumLength(100).WithMessage("max leanth is 100 char");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.RoleName)
                    .MustAsync(async (key, CancellationToken) => !await _authorizationService.IsRoleExistsByName(key)).WithMessage("Role is exist");


        }
    }
}
