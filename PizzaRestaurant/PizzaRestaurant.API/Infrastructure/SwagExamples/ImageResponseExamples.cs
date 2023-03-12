using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Images.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Infrastructure.SwagExamples
{
    public class ImageResponseExamples : IMultipleExamplesProvider<ImageResponseModel>
    {
        public IEnumerable<SwaggerExample<ImageResponseModel>> GetExamples()
        {
            yield return SwaggerExample.Create("example 1",
                new ImageResponseModel
                {
                    Id = 1,
                    OriginalName = "Pictur1",
                    Path = "Picture1Path",
                    PizzaId = 1,
                });

            yield return SwaggerExample.Create("example 2",
                new ImageResponseModel
                {
                    Id = 2,
                    OriginalName = "Pictur2",
                    Path = "Picture2Path",
                    PizzaId = 5,
                });
        }
    }
}
