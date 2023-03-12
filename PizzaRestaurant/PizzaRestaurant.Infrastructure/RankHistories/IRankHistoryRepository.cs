using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.RankHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.RankHistories
{
    public interface IRankHistoryRepository
    {
        Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken);
        Task<RankHistory> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, RankHistory rank);
        Task<bool> UserAlreadyRankedPizza(CancellationToken cancellationToken, RankHistory rank);
    }
}
