using Mapster;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Infrastructure.Orders;
using PizzaRestaurant.Infrastructure.Pizzas;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.Users;

namespace PizzaRestaurant.Application.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IPizzaRepository _pizzaRepo;
        private readonly IUserRepository _userRepo;
        public OrderService(IOrderRepository repo, IPizzaRepository pizzaRepo, IUserRepository userRepo)
        {
            _repo = repo;
            _pizzaRepo = pizzaRepo;
            _userRepo = userRepo;
        }
        public async Task<OrderResponseModel> CreateAsync(CancellationToken cancellationToken, OrderRequestModel orderRequest)
        {
            var pizza = await _pizzaRepo.GetAsync(cancellationToken, orderRequest.PizzaId);
            if (pizza == null)
                throw new ItemNotFoundException(ClassNames.Pizza + " " + ErrorMessages.NotFound, nameof(Pizza));

            var user = await _userRepo.GetAsync(cancellationToken, orderRequest.UserId);
            if (user == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            if (user.Addresses.Where(address => address.Id == orderRequest.AddressId) == null || user.Addresses.Count == 0)
            {
                throw new ConflictingUserAddressException(ErrorMessages.UserAddressConflict);
            }

            var order = orderRequest.Adapt<Order>();
            await _repo.CreateAsync(cancellationToken, order);
            return order.Adapt<OrderResponseModel>();
        }

        public async Task<List<OrderResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var orders = await _repo.GetAllAsync(cancellationToken);
            return orders.Adapt<List<OrderResponseModel>>();
        }

        public async Task<OrderResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var order = await _repo.GetAsync(cancellationToken, id);

            if (order == null)
                throw new ItemNotFoundException(ClassNames.Order + " " + ErrorMessages.NotFound, nameof(Order));

            else
                return order.Adapt<OrderResponseModel>();
        }
    }
}
