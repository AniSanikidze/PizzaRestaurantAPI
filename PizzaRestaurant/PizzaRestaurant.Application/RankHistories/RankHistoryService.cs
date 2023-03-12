using Mapster;
using Microsoft.EntityFrameworkCore;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Infrastructure.Images;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.RankHistories;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.RankHistories;
using PizzaRestaurnat.Domain.Users;

namespace PizzaRestaurant.Application.RankHistories
{
    public class RankHistoryService : IRankHistoryService
    {
        private readonly IRankHistoryRepository _repo;
        private readonly IPizzaRepository _pizzaRepo;
        private readonly IUserRepository _userRepo;
        private readonly IOrderRepository _orderRepo;
        public RankHistoryService(IRankHistoryRepository repo, IPizzaRepository pizzaRepo, IUserRepository userRepo,IOrderRepository orderRepo)
        {
            _repo = repo;
            _pizzaRepo = pizzaRepo;
            _userRepo = userRepo;
            _orderRepo = orderRepo;
        }
        public async Task<RankHistoryResponseModel> CreateAsync(CancellationToken cancellationToken, RankHistoryRequestModel rankRequest)
        {
            var rank = rankRequest.Adapt<RankHistory>();
            var userAlreadyRankedPizza = await _repo.UserAlreadyRankedPizza(cancellationToken, rank);

            if (userAlreadyRankedPizza)
                throw new RankConflictException(ErrorMessages.RankConflict);

            var pizza = await _pizzaRepo.GetAsync(cancellationToken, rank.PizzaId);

            if(pizza == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            var user = await _userRepo.GetAsync(cancellationToken, rank.UserId);
            
            if (user == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            var orderByPizzaAndUser = await _orderRepo.GetOrdersByUserAndPizza(cancellationToken, user.Id, pizza.Id);
            if (orderByPizzaAndUser == null || orderByPizzaAndUser.Count == 0)
            {
                throw new UserHasNotOrderedPizzaException(ErrorMessages.UserHasNotOrderedPizza);
            }
            await _repo.CreateAsync(cancellationToken, rank);
            return rank.Adapt<RankHistoryResponseModel>(); 
        }

        public async Task<List<RankHistoryResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var ranks = await _repo.GetAllAsync(cancellationToken);
            return ranks.Adapt<List<RankHistoryResponseModel>>();
        }

        public async Task<RankHistoryResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var rank = await _repo.GetAsync(cancellationToken, id);

            if (rank == null)
                throw new ItemNotFoundException(ClassNames.Rank + " " + ErrorMessages.NotFound, nameof(RankHistory));

            else
                return rank.Adapt<RankHistoryResponseModel>();
        }
    }
}
