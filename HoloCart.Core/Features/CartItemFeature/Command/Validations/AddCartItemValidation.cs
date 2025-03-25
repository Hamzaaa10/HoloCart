using FluentValidation;
using HoloCart.Core.Features.CartItemFeature.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.CartItemFeature.Command.Validations
{
    public class AddCartItemValidation : AbstractValidator<AddCartItemCommand>
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public AddCartItemValidation(IProductService productService, ICartService cartService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _productService = productService;
            _cartService = cartService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.CartId).NotEmpty().WithMessage("CartId is requierd")
                               .NotNull().WithMessage("CartId can't be nulll");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is requierd")
                                .NotNull().WithMessage("ProductId can't be nulll");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is requierd")
                                           .NotNull().WithMessage("Quantity can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.CartId)
                  .MustAsync(async (key, CancellationToken) => await _cartService.GetCartByIdAsync(key) != null).WithMessage("Cart was not found");
            RuleFor(x => x.ProductId)
                  .MustAsync(async (key, CancellationToken) => await _productService.GetByIdAcync(key) != null).WithMessage("Product was not found");
        }
    }
}
