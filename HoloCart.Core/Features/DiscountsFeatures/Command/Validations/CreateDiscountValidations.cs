﻿using FluentValidation;
using HoloCart.Core.Features.DiscountsFeatures.Command.Requests;
using HoloCart.Service.Abstract;

namespace HoloCart.Core.Features.DiscountsFeatures.Command.Validations
{
    public class CreateDiscountValidations : AbstractValidator<CreateDiscountCommand>
    {
        private readonly IDiscountService _discountService;

        public CreateDiscountValidations(IDiscountService discountService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _discountService = discountService;
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code is requierd")
                                .NotNull().WithMessage("Code can't be nulll");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("StartDate is requierd")
                               .NotNull().WithMessage("StartDate can't be nulll");

            RuleFor(x => x.EndDate).NotEmpty().WithMessage("EndDate is requierd")
                                    .NotNull().WithMessage("EndDate can't be nulll");


            RuleFor(x => x.Percentage).NotEmpty().WithMessage("Code is requierd")
                                    .NotNull().WithMessage("Code can't be nulll");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.Code)
                  .MustAsync(async (key, CancellationToken) => !await _discountService.IsDiscountCodeExists(key)).WithMessage("Discount Code is already existes");
        }
    }
}