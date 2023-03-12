using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurnat.Domain.Addresses
{
    public class Address
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string City { get; set; }
        public string Coutry { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<Order> Orders { get; set; }
    }
}
