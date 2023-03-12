using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Application.Users
{
    public interface IUserService
    {       
        Task<UserResponseModel> GetAsync(CancellationToken cancellationToken, int id);
        Task<List<UserResponseModel>> GetAllAsync(CancellationToken cancellationToken);
        Task<UserResponseModel> CreateAsync(CancellationToken cancellationToken, UserRequestModel person);
        Task<UserResponseModel> UpdateAsync(CancellationToken cancellationToken, UpdateUserRequestModel person, int id);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
    }
}
