using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaRestaurnat.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
