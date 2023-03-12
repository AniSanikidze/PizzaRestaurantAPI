using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localizations;
using PizzaRestaurant.Application.Pizzas.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class PizzaRequestValidator : AbstractValidator<PizzaRequestModel>
    {
        public PizzaRequestValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x.Length >= 3 && x.Length <= 20)
                .WithMessage(ValidationErrorMessages.PizzaNameLength);

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.PriceRequired);

            RuleFor(x => x.Description)
                .Must(desc => desc.Length <= 100)
                .WithMessage(ValidationErrorMessages.DescMaxLength);

            RuleFor(x => x.CaloryCount)
                .GreaterThan(0)
                .WithMessage(ValidationErrorMessages.CaloryCountRequired);
        }
    }
}
