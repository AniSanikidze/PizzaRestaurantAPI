using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Persistence;
using PizzaRestaurnat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Images
{
    public class ImageRepository : IImageRepository
    {
        #region Private Members

        private readonly PizzaRestaurantDbContext _dbContext;

        #endregion
        public ImageRepository(PizzaRestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(CancellationToken cancellationToken, Image image)
        {

                await _dbContext.Images.AddAsync(image, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
        }


        public async Task<List<Image>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Images.Where(image => !image.IsDeleted).ToListAsync(cancellationToken);
        }

        public async Task<Image> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await _dbContext.Images.SingleOrDefaultAsync(image => image.Id == id && !image.IsDeleted,
                cancellationToken);
        }

    }
}
