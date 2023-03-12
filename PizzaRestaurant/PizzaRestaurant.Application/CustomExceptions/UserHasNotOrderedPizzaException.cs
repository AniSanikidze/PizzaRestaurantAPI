using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.CustomExceptions
{
    public class UserHasNotOrderedPizzaException : Exception
    {
        public UserHasNotOrderedPizzaException(string? message) : base(message)
        {
        }
    }
}
