using PizzaRestaurant.Application.Pizzas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.RankHistories.Requests
{
    public class RankHistoryRequestModel
    {
        public int UserId { get; set; }
        public int PizzaId { get; set; }
        public int Rank { get; set; }
    }
}
