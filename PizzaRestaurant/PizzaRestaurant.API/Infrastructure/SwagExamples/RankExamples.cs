using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.RankHistories.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class RankExamples : IMultipleExamplesProvider<RankHistoryResponseModel>
    {
        public IEnumerable<SwaggerExample<RankHistoryResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 1",
               new RankHistoryResponseModel
               {
                   Id = 1,
                   UserId = 1,
                   PizzaId = 1,
                   Rank = 10
               });

            yield return SwaggerExample.Create("example 2",
               new RankHistoryResponseModel
               {
                   Id = 2,
                   UserId = 5,
                   PizzaId = 6,
                   Rank = 9
               });
        }
    }
}
