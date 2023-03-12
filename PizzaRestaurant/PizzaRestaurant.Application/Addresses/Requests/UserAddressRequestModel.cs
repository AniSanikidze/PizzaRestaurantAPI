using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Addresses.Requests
{
    public class UserAddressRequestModel
    {
        public string City { get; set; }
        public string Coutry { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
    }
}
