using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.RankHistories;

namespace PizzaRestaurant.Infrastructure.Orders
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync(CancellationToken cancellationToken);
        Task<Order> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Order order);
        Task <List<Order>> GetOrdersByUserAndPizza(CancellationToken cancellationToken, int userId, int pizzaId);
    }
}