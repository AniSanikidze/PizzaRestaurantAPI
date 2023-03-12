using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaRestaurnat.Domain.RankHistories;

namespace PizzaRestaurnat.Domain.Pizzas
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CaloryCount { get; set; }
        public List<Order> Orders { get; set; }
        public bool IsDeleted { get; set; }
        public List<RankHistory> RankHistories { get; set; }
        //public IList<PizzaOrder> PizzaOrders { get; set; }
        public Image Image { get; set; }
    }
}
