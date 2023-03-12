using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Orders
{
    public interface IOrderService
    {
        Task<OrderResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<OrderResponseModel> CreateAsync(CancellationToken cancellationToken, OrderRequestModel orderRequest);
    }
}
