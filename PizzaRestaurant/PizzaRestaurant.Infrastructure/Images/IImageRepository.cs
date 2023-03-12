using PizzaRestaurnat.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Infrastructure.Images
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllAsync(CancellationToken cancellationToken);
        Task<Image> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, Image image);
    }
}
