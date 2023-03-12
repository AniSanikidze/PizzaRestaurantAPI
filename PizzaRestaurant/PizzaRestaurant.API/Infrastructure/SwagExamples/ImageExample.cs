using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Images.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class ImageExample : IExamplesProvider<ImageResponseModel>
    {
        public ImageResponseModel GetExamples()
        {
            return new ImageResponseModel()
            {
                Id = 1,
                OriginalName = "Pictur1",
                Path = "Picture1Path",
                PizzaId = 1,
            };
        }
    }
}
