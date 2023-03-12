using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localizations;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Pizzas.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class AddressRequestValidator : AbstractValidator<AddressRequestModel>
    {
        public AddressRequestValidator()
        {
            RuleFor(x => x.City)
                .Must(city => city.Length > 0 && city.Length <= 15)
                .WithMessage(ValidationErrorMessages.CityRequired);

            RuleFor(x => x.Coutry)
                .Must(country => country.Length > 0 && country.Length <= 15)
                .WithMessage(ValidationErrorMessages.CountryRequired);

            RuleFor(x => x.Region)
                .Must(region => region.Length <= 15)
                .WithMessage(ValidationErrorMessages.RegionMaxLength);

            RuleFor(x => x.Description)
                .Must(desc => desc.Length <= 100)
                .WithMessage(ValidationErrorMessages.DescMaxLength);
        }
    }
}
