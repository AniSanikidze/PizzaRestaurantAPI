using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.CustomExceptions
{
    public class ItemNotFoundException : Exception
    {
        public string DomainClassName { get; private set; }
        public ItemNotFoundException(string? message, string domainClassName) : base(message)
        {
            DomainClassName = domainClassName + "NotFound";
        }
    }
}
