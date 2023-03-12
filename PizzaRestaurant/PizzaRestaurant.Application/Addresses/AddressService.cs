using Mapster;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.CustomExceptions;
using PizzaRestaurant.Application.Locals;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Infrastructure.Addresses;
using PizzaRestaurant.Infrastructure.Users;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Users;

namespace PizzaRestaurant.Application.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repo;
        private readonly IUserRepository _userRepo;
        public AddressService(IAddressRepository repo,IUserRepository userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
        public async Task<AddressResponseModel> CreateAsync(CancellationToken cancellationToken, AddressRequestModel addressRequest)
        {
            if (await _userRepo.GetAsync(cancellationToken, addressRequest.UserId) == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            var address = addressRequest.Adapt<Address>();
            await _repo.CreateAsync(cancellationToken, address);
            return address.Adapt<AddressResponseModel>();
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var address = await _repo.GetAsync(cancellationToken, id);

            if (address == null)
                throw new ItemNotFoundException(ClassNames.Address + " " + ErrorMessages.NotFound, nameof(Address));

            await _repo.DeleteAsync(cancellationToken, address);
        }

        public async Task<List<AddressResponseModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var addresses = await _repo.GetAllAsync(cancellationToken);
            return addresses.Adapt<List<AddressResponseModel>>();
        }

        public async Task<AddressResponseModel> GetAsync(CancellationToken cancellationToken, int id)
        {
            var address = await _repo.GetAsync(cancellationToken, id);

            if (address == null)
                throw new ItemNotFoundException(ClassNames.Address + " " + ErrorMessages.NotFound, nameof(Address));

            else
                return address.Adapt<AddressResponseModel>();
        }

        public async Task<AddressResponseModel> UpdateAsync(CancellationToken cancellationToken, AddressRequestModel addressRequestModel,int id)
        {
            if (await _repo.GetAsync(cancellationToken, id) == null)
                throw new ItemNotFoundException(ClassNames.Address + " " + ErrorMessages.NotFound, nameof(Address));

            if (await _userRepo.GetAsync(cancellationToken, addressRequestModel.UserId) == null)
                throw new ItemNotFoundException(ClassNames.User + " " + ErrorMessages.NotFound, nameof(User));

            var address = addressRequestModel.Adapt<Address>();
            address.Id = id;
            await _repo.UpdateAsync(cancellationToken, address);

            return address.Adapt<AddressResponseModel>();
        }
    }
}
