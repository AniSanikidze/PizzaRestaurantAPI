using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwaggerExamples
{
    public class AddressExample : IExamplesProvider<AddressResponseModel>
    {
        public AddressResponseModel GetExamples()
        {

            return new AddressResponseModel()
            {
                Id = 1,
                UserId = 1,
                City = "თბილისი",
                Coutry = "საქართველო",
                Region = "თბილისი",
                Description = "აღწერა..."
            };
        }
    }
}
