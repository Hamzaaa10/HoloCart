using FluentValidation;
using HoloCart.Core.Features.Authorization.Commands.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.Authorization.Commands.Validations
{
    public class DeleteRoleValidations : AbstractValidator<DeleteRoleRequest>
    {
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleValidations(IAuthorizationService authorizationService)
        {
            ApplayValidationrules();
            _authorizationService = authorizationService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("RoleName isrequierd")
                                .NotNull().WithMessage("RoleName Can't be null");

        }


    }
}
