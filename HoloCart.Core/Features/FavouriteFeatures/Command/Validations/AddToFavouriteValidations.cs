using FluentValidation;
using HoloCart.Core.Features.FavouriteFeatures.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.FavouriteFeatures.Command.Validations
{
    public class AddToFavouriteValidations : AbstractValidator<AddToFavouritesCommand>
    {
        private readonly IFavouritService _favouritService;

        public AddToFavouriteValidations(IFavouritService favouritService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _favouritService = favouritService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is requierd")
                                .NotNull().WithMessage("ProductId can't be nulll");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is requierd")
                               .NotNull().WithMessage("UserId can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.ProductId)
                  .MustAsync(async (model, key, CancellationToken) => !await _favouritService.IsProductInFavourit(key, model.UserId)).WithMessage("Discount Code is already existes");
        }
    }
}