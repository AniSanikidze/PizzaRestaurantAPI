using PizzaRestaurant.API.Infrastructure.Middlewares;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
    public static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<CultureMiddleware>();
            return applicationBuilder;
        }
    }
}
