using FluentValidation;
using HoloCart.Core.Features.ShippingAddressFeatures.command.Requests;

namespace HoloCart.Core.Features.ShippingAddressFeatures.command.Validations
{
    public class UpdateShippingAddressValidations : AbstractValidator<UpdateShippingAddressCommand>
    {

        public UpdateShippingAddressValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is requierd")
                                .NotNull().WithMessage("UserId can't be nulll");
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("AddressLine1 is requierd")
                               .NotNull().WithMessage("AddressLine1 can't be nulll");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is requierd")
                                .NotNull().WithMessage("State can't be nulll");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is requierd")
                               .NotNull().WithMessage("City can't be nulll");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("ZipCode is requierd")
                               .NotNull().WithMessage("ZipCode can't be nulll");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is requierd")
                               .NotNull().WithMessage("Country can't be nulll");







        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}