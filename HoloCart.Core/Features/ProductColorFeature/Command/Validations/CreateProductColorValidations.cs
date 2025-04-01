using FluentValidation;
using HoloCart.Core.Features.ProductColorFeature.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.ProductColorFeature.Command.Validations
{
    public class CreateProductColorValidations : AbstractValidator<CreateProductColorCommand>
    {
        private readonly IProductService _productService;

        public CreateProductColorValidations(IProductService productService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _productService = productService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Name is requierd")
                                .NotNull().WithMessage("Name can't be nulll");
            RuleFor(x => x.ColorName).NotEmpty().WithMessage("MainImageUrl is requierd")
                               .NotNull().WithMessage("MainImageUrl can't be nulll");
            RuleFor(x => x.ColorHex).NotEmpty().WithMessage("CategoryId is requierd")
                                .NotNull().WithMessage("CategoryId can't be nulll");







        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.ProductId)
                 .MustAsync(async (key, CancellationToken) => await _productService.GetByIdAcync(key) != null).WithMessage("Product is Not existes");
        }
    }
}
