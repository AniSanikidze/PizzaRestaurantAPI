using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Pizzas
{
    public interface IPizzaService
    {
        Task<PizzaResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<PizzaResponseModel> CreateAsync(CancellationToken cancellationToken, PizzaRequestModel person);
        Task<PizzaResponseModel> UpdateAsync(CancellationToken cancellationToken, PizzaRequestModel person, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
