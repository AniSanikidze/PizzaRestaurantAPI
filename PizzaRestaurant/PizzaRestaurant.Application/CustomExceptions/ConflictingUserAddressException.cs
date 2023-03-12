using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.CustomExceptions
{
    public class ConflictingUserAddressException : Exception
    {
        public ConflictingUserAddressException(string? message) : base(message)
        {
        }
    }
}
