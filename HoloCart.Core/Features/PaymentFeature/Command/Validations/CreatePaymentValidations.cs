using FluentValidation;
using HoloCart.Core.Features.PaymentFeature.Command.Requests;

namespace HoloCart.Core.Features.PaymentFeature.Command.Validations
{
    public class CreatePaymentValidations : AbstractValidator<CreatePaymentCommand>
    {

        public CreatePaymentValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("Code is requierd")
                                .NotNull().WithMessage("Code can't be nulll");
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("StartDate is requierd")
                               .NotNull().WithMessage("StartDate can't be nulll");

            RuleFor(x => x.Amount).NotEmpty().WithMessage("EndDate is requierd")
                                    .NotNull().WithMessage("EndDate can't be nulll");

        }
        public void ApplayCustomValidationrules()
        {
        }
    }
}