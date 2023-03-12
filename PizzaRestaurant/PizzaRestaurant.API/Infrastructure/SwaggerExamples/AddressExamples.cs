using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwaggerExamples
{
    public class AddressExamples : IMultipleExamplesProvider<AddressResponseModel>
    {
        public IEnumerable<SwaggerExample<AddressResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 1", new AddressResponseModel
            {
                        Id = 1,
                        UserId = 1,
                        City = "თბილისი",
                        Coutry = "საქართველო",
                        Region = "თბილისი",
                        Description = "აღწერა..."
            });
            yield return SwaggerExample.Create("example 2", new AddressResponseModel
            {
                Id = 2,
                UserId = 5,
                City = "Vienna",
                Coutry = "Austria",
                Region = "Vienna",
                Description = "Desc..."
            });

        }
    }
}
