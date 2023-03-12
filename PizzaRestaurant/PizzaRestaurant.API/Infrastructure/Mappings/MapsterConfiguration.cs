using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.RankHistories;
using PizzaRestaurnat.Domain.Users;

namespace PizzaRestaurant.API.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<Address, AddressResponseModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<User, UserResponseModel>
                .NewConfig()
                .TwoWays();
            TypeAdapterConfig<AddressRequestModel, Address>
                .NewConfig();
            TypeAdapterConfig<UserRequestModel, User>
                .NewConfig();
            TypeAdapterConfig<Image, ImageResponseModel>
                .NewConfig();
            TypeAdapterConfig<Pizza, PizzaResponseModel>
                .NewConfig()
                .Map(dest => dest.AverageRank, src => src.RankHistories.Count > 0 ? src.RankHistories.Average(rh => rh.Rank) : -1)
                .Map(dest => dest.ImageFullPath, src => src.Image != null ? src.Image.Path : "");

            TypeAdapterConfig<RankHistory, RankHistoryResponseModel>
                .NewConfig();

            TypeAdapterConfig<RankHistoryRequestModel, RankHistory>
                .NewConfig();

        }
    }
}
