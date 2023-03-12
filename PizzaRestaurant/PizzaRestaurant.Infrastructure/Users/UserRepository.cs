using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PizzaRestaurant.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion

        public UserRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, User user)
        {
            await _dbContext.Users.AddAsync(user, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var user = await GetAsync(cancellationToken, id);
            user.IsDeleted = true;
            user.Addresses.ForEach(a => a.IsDeleted = true);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Users.Include(u => u.Addresses.Where(address => !address.IsDeleted)).Where(user => !user.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<User> GetAsync(CancellationToken cancellationToken, int id)
        {
            var user = await _dbContext.Users.Include(u => u.Addresses.Where(address => !address.IsDeleted)).SingleOrDefaultAsync(user => user.Id == id && !user.IsDeleted, cancellationToken);
            return user;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, User user)
        {
            _dbContext.Entry(user).State = EntityState.Detached;
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
