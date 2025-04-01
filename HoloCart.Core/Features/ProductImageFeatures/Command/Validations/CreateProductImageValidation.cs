using FluentValidation;
using HoloCart.Core.Features.ProductImageFeatures.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.ProductImageFeatures.Command.Validations
{
    public class CreateProductImageValidation : AbstractValidator<CreateProductImageCommand>
    {
        private readonly IProductColorService _productColorService;

        public CreateProductImageValidation(IProductColorService productColorService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _productColorService = productColorService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.ProductColorId).NotEmpty().WithMessage("ProductColorId is requierd")
                                .NotNull().WithMessage("ProductColorId can't be nulll");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is requierd")
                               .NotNull().WithMessage("ImageUrl can't be nulll");








        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.ProductColorId)
                 .MustAsync(async (key, CancellationToken) => await _productColorService.GetProductColorById(key) != null).WithMessage("ProductColor is Not existes");
        }

    }
}
