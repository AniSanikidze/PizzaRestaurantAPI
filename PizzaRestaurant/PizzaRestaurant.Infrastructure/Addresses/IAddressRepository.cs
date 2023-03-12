using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Addresses
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAllAsync(CancellationToken cancellationToken);
        Task<Address> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Address address);
        Task UpdateAsync(CancellationToken cancellationToken, Address address);
        Task DeleteAsync(CancellationToken cancellationToken, Address address);
    }
}
