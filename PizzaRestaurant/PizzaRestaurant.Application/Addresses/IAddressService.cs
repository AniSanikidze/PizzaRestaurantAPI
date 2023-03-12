using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Addresses
{
    public interface IAddressService
    {
        Task<AddressResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<AddressResponseModel> CreateAsync(CancellationToken cancellationToken, AddressRequestModel person);
        Task<AddressResponseModel> UpdateAsync(CancellationToken cancellationToken, AddressRequestModel person, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
