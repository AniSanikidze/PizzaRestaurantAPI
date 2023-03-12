using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class PizzaExample : IExamplesProvider<PizzaResponseModel>
    {
        public PizzaResponseModel GetExamples()
        {
            return new PizzaResponseModel
            {
                Id = 1,
                Name = "Margarita",
                Description = "Margartida Desc...",
                AverageRank = 8,
                CaloryCount = 350,
                ImageFullPath = "Margarita.jpg",
                Price = 30
            };
        }
    }
}
