using FluentValidation;
using HoloCart.Core.Features.OrderItemFeature.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.OrderItemFeature.Command.Responses
{
    public class CreateOrderItemValidation : AbstractValidator<CreateOrderItemCommand>
    {
        private readonly IProductService _productService;

        public CreateOrderItemValidation(IProductService productService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _productService = productService;

        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("UnitPrice is requierd")
                                .NotNull().WithMessage("UnitPrice can't be nulll");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is requierd")
                               .NotNull().WithMessage("ProductId can't be nulll");

            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is requierd")
                                    .NotNull().WithMessage("OrderId can't be nulll");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is requierd")
                                    .NotNull().WithMessage("Quantity can't be nulll");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.ProductId)
                  .MustAsync(async (key, CancellationToken) => await _productService.GetByIdAcync(key) == null).WithMessage("Product with this id is not existes");

        }
    }
}