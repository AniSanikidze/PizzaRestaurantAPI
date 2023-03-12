using FluentValidation;
using PizzaRestaurant.API.Infrastructure.Localizations;
using PizzaRestaurant.Application.RankHistories.Requests;

namespace PizzaRestaurant.API.Infrastructure.Validators
{
    public class RankHistoryRequestValidator : AbstractValidator<RankHistoryRequestModel>
    {
        public RankHistoryRequestValidator()
        {
            RuleFor(x => x.Rank)
                .Must(rank => rank >= 1 && rank <= 10)
                .WithMessage(ValidationErrorMessages.PizzaRankLimit);
        }
    }
}
