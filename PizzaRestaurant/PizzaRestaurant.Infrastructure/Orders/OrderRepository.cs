using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion
        public OrderRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Order order)
        {
            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Orders.Where(order => !order.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<Order> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(order => order.Id == id && !order.IsDeleted,
                cancellationToken);
        }

        public async Task<List<Order>> GetOrdersByUserAndPizza(CancellationToken cancellationToken, int userId, int pizzaId)
        {
            return await _dbContext.Orders.Where(order => order.PizzaId == pizzaId && order.UserId == userId).ToListAsync(cancellationToken); ;
        }
    }
}