using PizzaRestaurant.API.Infrastructure.Middlewares;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
    public static class RequestLoggingMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<RequestLoggingMiddleware>();
            return applicationBuilder;
        }
    }
}
