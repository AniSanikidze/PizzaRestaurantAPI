using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain.RankHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PizzaRestaurant.Infrastructure.RankHistories
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion
        public RankHistoryRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, RankHistory rank)
        {
            await _dbContext.RankHistories.AddAsync(rank, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<RankHistory>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.RankHistories.Where(rh => !rh.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<RankHistory> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbContext.RankHistories.SingleOrDefaultAsync(rh => rh.Id == id && !rh.IsDeleted,
                cancellationToken);
        }

        public async Task<bool> UserAlreadyRankedPizza(CancellationToken cancellationToken,RankHistory rank)
        {
            var retrievedRank = await _dbContext.RankHistories.SingleOrDefaultAsync(rh => rh.UserId == rank.UserId && rh.PizzaId == rank.PizzaId);
            if(retrievedRank != null)
                return true;
            return false;
        }

    }
}
