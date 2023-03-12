using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurnat.Domain.RankHistories
{
    public class RankHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int Rank { get; set; }
        public bool IsDeleted { get; set; }
    }
}
