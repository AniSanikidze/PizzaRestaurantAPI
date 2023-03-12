using PizzaRestaurant.Application.Addresses;
using PizzaRestaurant.Application.Images;
using PizzaRestaurant.Application.Orders;
using PizzaRestaurant.Application.Pizzas;
using PizzaRestaurant.Application.RankHistories;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Images;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.RankHistories;
using PizzaRestaurant.Infrastructure.Users;

namespace PizzaRestaurant.API.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPizzaService, PizzaService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IPizzaRepository, PizzaRepository>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IRankHistoryService, RankHistoryService>();
            services.AddScoped<IRankHistoryRepository, RankHistoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

        }
    }
}
