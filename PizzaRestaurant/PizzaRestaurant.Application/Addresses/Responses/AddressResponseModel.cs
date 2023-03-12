using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Addresses.Responses
{
    public class AddressResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Coutry { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
    }
}
