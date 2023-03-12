using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localizations;
using PizzaRestaurant.Application.Users.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class UserRequestValidator : AbstractValidator<UserRequestModel>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .Must(x => x.Length >= 2 && x.Length <= 20)
                .WithMessage(ValidationErrorMessages.Firstname);

            RuleFor(x => x.LastName)
                .Must(x => x.Length >= 2 && x.Length <= 30)
                .WithMessage(ValidationErrorMessages.Lastname);

            RuleFor(x => x.Email)
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage(ValidationErrorMessages.InvalidEmail)
                .NotEmpty()
                .WithMessage(ValidationErrorMessages.EmailRequired);

            RuleFor(x => x.PhoneNumber)
                .Matches(@"^5[1-9]{2}\d{6}")
                .WithMessage(ValidationErrorMessages.InvalidPhoneNumber);

            When(x => x.Addresses != null && x.Addresses.Count > 0, () =>
            {
                RuleForEach(x => x.Addresses).SetValidator(new UserAddressRequestValidator());
            });

            //RuleFor(x => x.Addresses)
                //.Must(addresses => addresses == null || addresses.Count > 0)
                //.WithMessage("Addresses fiekd can be null or a list of addresses");
        }
    }
}
