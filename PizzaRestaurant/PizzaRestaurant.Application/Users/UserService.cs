using Mapster;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurnat.Domain.Users;

namespace PizzaRestaurant.Application.Users
{
    public class UserService : IUserService
    {
        private IUserRepository _repo;
        private IAddressRepository _addressRepo;
        public UserService(IUserRepository repo, IAddressRepository addressRepo)
        {
            _repo = repo;
            _addressRepo = addressRepo;
        }
        public async Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var user = await _repo.GetAsync(cancellationToken, id);

            if (user == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            else
                return user.Adapt<UserResponseModel>();
        }
        public async Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _repo.GetAllAsync(cancellationToken);
            return users.Adapt<List<UserResponseModel>>();
        }
        public async Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken, UserRequestModel userRequest)
        {
            var user = userRequest.Adapt<User>();
            await _repo.CreateAsync(cancellationToken, user);
            user.Addresses.ForEach(async address =>
            {
                address.UserId = user.Id;
                await _addressRepo.CreateAsync(cancellationToken, address);
            });
            return user.Adapt<UserResponseModel>();
        }

        public async Task<UserResponseModel> UpdateAsync(CancellationToken cancellationToken, UpdateUserRequestModel userRequest, int id)
        {
            if (await _repo.GetAsync(cancellationToken, id) == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            var user = userRequest.Adapt<User>();
            user.Id = id;
            await _repo.UpdateAsync(cancellationToken, user);

            return user.Adapt<UserResponseModel>();
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            if (await _repo.GetAsync(cancellationToken, id) == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            await _repo.DeleteAsync(cancellationToken, id);
        }
    }
}
