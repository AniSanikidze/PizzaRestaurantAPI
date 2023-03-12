using PizzaRestaurant.Application.Images.Requests;
using PizzaRestaurant.Application.Images.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Images
{
    public interface IImageService
    {
        Task<ImageResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<ImageResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<ImageResponseModel> CreateAsync(CancellationToken cancellationToken, ImageRequestModel imageRequest);
    }
}
