using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Pizzas
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAllAsync(CancellationToken cancellationToken);
        Task<Pizza> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Pizza pizza);
        Task UpdateAsync(CancellationToken cancellationToken, Pizza pizza);
        Task DeleteAsync(CancellationToken cancellationToken, Pizza pizza);
    }
}
