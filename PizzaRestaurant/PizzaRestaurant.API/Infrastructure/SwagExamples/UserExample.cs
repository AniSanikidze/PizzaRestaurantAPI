using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class UserExample : IExamplesProvider<UserResponseModel>
    {
        public UserResponseModel GetExamples()
        {
            return new UserResponseModel()
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

            };
        }
    }
}
