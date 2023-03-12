using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.RankHistories.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class RankExample : IExamplesProvider<RankHistoryResponseModel>
    {
        public RankHistoryResponseModel GetExamples()
        {
            return new RankHistoryResponseModel
            {
                Id = 1,
                PizzaId = 1,
                Rank = 8,
                UserId = 5
            };
        }
    }
}
