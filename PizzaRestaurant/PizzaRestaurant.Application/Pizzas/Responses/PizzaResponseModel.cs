using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurnat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Pizzas.Responses
{
    public class PizzaResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageFullPath { get; set; }
        public int CaloryCount { get; set; }
        public int AverageRank { get; set; }
    }
}
