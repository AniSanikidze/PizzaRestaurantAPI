using PizzaRestaurnat.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurnat.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
