using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Orders.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class OrderExample : IExamplesProvider<OrderResponseModel>
    {
        public OrderResponseModel GetExamples()
        {
            return new OrderResponseModel()
            {
                Id = 1,
                AddressId = 1,
                PizzaId = 2,
                UserId = 3,
            };
        }
    }
}
