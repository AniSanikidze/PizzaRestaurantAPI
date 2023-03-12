using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.RankHistories
{
    public interface IRankHistoryService
    {
        Task<RankHistoryResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<RankHistoryResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<RankHistoryResponseModel> CreateAsync(CancellationToken cancellationToken, RankHistoryRequestModel rankRequest);
    }
}
