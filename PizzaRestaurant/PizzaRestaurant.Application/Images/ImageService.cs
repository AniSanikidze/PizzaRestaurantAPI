using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Images.Requests;
using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Images;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Images
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _repo;
        private readonly IPizzaRepository _pizzaRepo;
        public ImageService(IImageRepository repo, IPizzaRepository pizzaRepo)
        {
            _repo = repo;
            _pizzaRepo = pizzaRepo;
        }
        public async Task<ImageResponseModel> CreateAsync(CancellationToken cancellationToken, ImageRequestModel imageRequest)
        {
            var pizza = _pizzaRepo.GetAsync(cancellationToken, imageRequest.PizzaId);
            if(pizza == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            var image = imageRequest.Adapt<Image>();
            await _repo.CreateAsync(cancellationToken, image);
            return image.Adapt<ImageResponseModel>();
        }

        public async Task<List<ImageResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var images = await _repo.GetAllAsync(cancellationToken);
            return images.Adapt<List<ImageResponseModel>>();
        }

        public async Task<ImageResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var image = await _repo.GetAsync(cancellationToken, id);

            if (image == null)
                throw new ItemNotFoundException(ClassNames.Image + " " + ErrorMessages.NotFound, nameof(Image));

            else
                return image.Adapt<ImageResponseModel>();
        }

    }
}
