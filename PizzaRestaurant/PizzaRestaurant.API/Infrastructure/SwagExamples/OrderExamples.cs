using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Application.Pizzas.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class OrderExamples : IMultipleExamplesProvider<OrderResponseModel>
    {
        public IEnumerable<SwaggerExample<OrderResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 2",
               new OrderResponseModel
               {
                   Id = 2,
                   AddressId = 3,
                   PizzaId = 4,
                   UserId = 5,
               });
            yield return SwaggerExample.Create("example 2",
               new OrderResponseModel
               {
                   Id = 3,
                   AddressId = 1,
                   PizzaId = 2,
                   UserId = 2,
               });
        }
    }
}
