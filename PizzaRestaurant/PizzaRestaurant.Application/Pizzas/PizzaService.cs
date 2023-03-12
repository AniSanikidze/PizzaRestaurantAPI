using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Pizzas
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepository _repo;

        public PizzaService(IPizzaRepository repo)
        {
            _repo = repo;
        }
        public async Task<PizzaResponseModel> CreateAsync(CancellationToken cancellationToken, PizzaRequestModel pizzaRequest)
        {
            var pizza = pizzaRequest.Adapt<Pizza>();
            await _repo.CreateAsync(cancellationToken, pizza);
            var createdPizza = await _repo.GetAsync(cancellationToken, pizza.Id);
            var response = createdPizza.Adapt<PizzaResponseModel>();
            return response;
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var pizza = await _repo.GetAsync(cancellationToken, id);

            if (pizza == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            await _repo.DeleteAsync(cancellationToken, pizza);
        }

        public async Task<List<PizzaResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var pizzas = await _repo.GetAllAsync(cancellationToken);
            return pizzas.Adapt<List<PizzaResponseModel>>();
        }

        public async Task<PizzaResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var pizza = await _repo.GetAsync(cancellationToken, id);

            if (pizza == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            else
                return pizza.Adapt<PizzaResponseModel>();
        }

        public async Task<PizzaResponseModel> UpdateAsync(CancellationToken cancellationToken, PizzaRequestModel pizzaRequest, int id)
        {
            if (await _repo.GetAsync(cancellationToken, id) == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            var pizza = pizzaRequest.Adapt<Pizza>();
            pizza.Id = id;
            await _repo.UpdateAsync(cancellationToken, pizza);

            var updatedPizza = await _repo.GetAsync(cancellationToken, id);
            var response = updatedPizza.Adapt<PizzaResponseModel>();
            return response;
        }
    }
}
