using PizzaRestaurant.Application.Pizzas.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Orders.Requests
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int PizzaId { get; set; }
    }
}
