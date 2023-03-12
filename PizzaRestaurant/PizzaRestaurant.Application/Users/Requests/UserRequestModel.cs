using PizzaRestaurant.Application.Addresses.Requests;

namespace PizzaRestaurant.Application.Users.Requests
{
    public class UserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<UserAddressRequestModel>? Addresses { get; set; }
    }
}
