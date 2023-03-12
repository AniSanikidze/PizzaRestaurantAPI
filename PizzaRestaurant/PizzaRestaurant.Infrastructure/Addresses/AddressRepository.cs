using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion
        public AddressRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Address address)
        {
                await _dbContext.Addresses.AddAsync(address, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, Address address)
        {
            //var address = await _dbContext.Addresses.SingleOrDefaultAsync(address => address.Id == id && !address.IsDeleted, cancellationToken);
            //if (address != null)
            //{
                address.IsDeleted = true;
                _dbContext.Addresses.Update(address);
                await _dbContext.SaveChangesAsync(cancellationToken);
            //}
            //else
            //{
            //    throw new Exception("Address was not found");
            //}
        }

        public async Task<List<Address>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Addresses.Where(address => !address.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<Address> GetAsync(CancellationToken cancellationToken, int id)
        {
            var address = await _dbContext.Addresses.SingleOrDefaultAsync(address => address.Id == id && !address.IsDeleted, 
                cancellationToken);
            //if(address != null)
            //    _dbContext.Entry(address).State = EntityState.Detached;
            return address;
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, Address address)
        {
            //var retrievedAddress = await _dbContext.Addresses.FindAsync(address.Id, cancellationToken);
            //if (retrievedAddress != null && !retrievedAddress.IsDeleted)
            //{
            //    _dbContext.Entry(retrievedAddress).State = EntityState.Detached;
            //    var user = await _dbContext.Users.FindAsync(address.UserId, cancellationToken);

            //    if (user != null && !user.IsDeleted)
            //    {
                    //_dbContext.Entry(address).State = EntityState.Detached;
                    //_dbContext.Addresses.Update(address);
            var retrievedAddress = await GetAsync(cancellationToken, address.Id);

                    _dbContext.Entry(retrievedAddress).CurrentValues.SetValues(address);
                    await _dbContext.SaveChangesAsync(cancellationToken);
            //    }
            //    else
            //    {
            //        throw new Exception("Corresponding user not found");
            //    }
            //}
            //else
            //{
            //    throw new Exception("Address not found");
            //}
        }
    }
}
