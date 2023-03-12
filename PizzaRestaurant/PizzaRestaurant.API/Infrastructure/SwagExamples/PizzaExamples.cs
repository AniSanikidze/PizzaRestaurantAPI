using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class PizzaExamples : IMultipleExamplesProvider<PizzaResponseModel>
    {
        public IEnumerable<SwaggerExample<PizzaResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 1",
               new PizzaResponseModel
               {
                   Id = 1,
                   Name = "Margarita",
                   Description = "Margartida Desc...",
                   AverageRank = 8,
                   CaloryCount = 350,
                   ImageFullPath = "Margarita.jpg",
                   Price = 30
               });

            yield return SwaggerExample.Create("example 2",
               new PizzaResponseModel
               {
                   Id = 2,
                   Name = "Peperon",
                   Description = "Peperon Desc...",
                   AverageRank = 9,
                   CaloryCount = 370,
                   ImageFullPath = "Pepron.jpg",
                   Price = 40
               });
        }
    }
}
