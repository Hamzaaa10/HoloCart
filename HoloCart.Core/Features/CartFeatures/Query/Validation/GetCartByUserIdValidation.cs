using FluentValidation;
using HoloCart.Core.Features.CartFeatures.Query.Requests;
using HoloCart.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace HoloCart.Core.Features.CartFeatures.Query.Validation
{
    public class GetCartByUserIdValidation : AbstractValidator<GetCartByUserIdQuery>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetCartByUserIdValidation(UserManager<ApplicationUser> userManager)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _userManager = userManager;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.UserId)
                  .MustAsync(async (key, CancellationToken) => await _userManager.FindByIdAsync(key.ToString()) != null).WithMessage("User with this Id was not found");
        }
    }
}


