using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Pizzas
{
    public class PizzaRepository : IPizzaRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion
        public PizzaRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Pizza pizza)
        {
            await _dbContext.Pizzas.AddAsync(pizza, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, Pizza pizza)
        {
            pizza.IsDeleted = true;
            if (pizza.RankHistories != null)
            {
                pizza.RankHistories.ForEach(rh => rh.IsDeleted = true);
            }
            _dbContext.Pizzas.Update(pizza);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Pizza>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Pizzas.Include(p => p.Image).Include(p => p.RankHistories.Where(rh => !rh.IsDeleted))
                .Where(pizza => !pizza.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<Pizza> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbContext.Pizzas.Include(p => p.Image).Include(p => p.RankHistories.Where(rh => !rh.IsDeleted)).SingleOrDefaultAsync(pizza => pizza.Id == id && !pizza.IsDeleted, cancellationToken);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Pizza pizza)
        {
            var retrievedPizza = await GetAsync(cancellationToken, pizza.Id);

            _dbContext.Entry(retrievedPizza).CurrentValues.SetValues(pizza);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
