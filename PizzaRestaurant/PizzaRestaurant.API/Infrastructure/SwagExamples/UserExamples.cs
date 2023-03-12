using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class UsersExample : IMultipleExamplesProvider<UserResponseModel>
    {
        public IEnumerable<SwaggerExample<UserResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 1", new UserResponseModel
            {
                Id = 1,
                FirstName = "ანი",
                LastName = "სანიკიძე",
                PhoneNumber = "578898586",
                Addresses = new List<AddressResponseModel>
                {
                    new AddressResponseModel()
                    {
                        Id = 1,
                        UserId = 1,
                        City = "თბილისი",
                        Coutry = "საქართველო",
                        Region = "თბილისი",
                        Description = "აღწერა..."
                    }
                },
                Email = "ani@gmail.com",
            });

            yield return SwaggerExample.Create("example 2", new UserResponseModel
            {
                Id = 2,
                FirstName = "User2",
                LastName = "User2 Lastname",
                PhoneNumber = "577456897",
                Addresses = new List<AddressResponseModel>(),
                Email = "user2@gmail.com",
            });
        }
    }
}
