using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService userService)
        {
            _service = userService;
        }
        /// <summary>
        /// Returns user by id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>User data</returns>
        /// <response code="200">Returns the specific user's data</response>
        /// <response code="404">If the user was not found</response>
        [ProducesResponseType(typeof(UserResponseModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }
        /// <summary>
        /// Returns list of users
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>list of users</returns>
        [ProducesResponseType(typeof(IEnumerable<UserResponseModel>),StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UsersExample))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }

        /// <summary>
        /// Creates user
        /// </summary>
        /// <remarks>
        /// Note that Id is not necessary
        /// 
        ///     POST/User
        ///     
        ///     {
        ///        "firstName": "ანი",
        ///         "lastName": "სანიკიძე",
        ///         "email": "ani@gmail.com",
        ///         "phoneNumber": "578898586",
        ///         "addresses": [
        ///             {
        ///                 "city": "თბილისი",
        ///                 "coutry": "საქართველო",
        ///                 "region": "თბილისი",
        ///                 "description": "აღწერა..."
        ///             }
        ///         ]
        ///     }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>New Created person's Id</returns>
        /// <response code="200">Returns the newly created user's data</response>
        [ProducesResponseType(typeof(UserResponseModel),StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<UserResponseModel>> Post(CancellationToken cancellationToken, UserRequestModel request)
        {
            return Ok(await _service.CreateAsync(cancellationToken, request));
        }

        /// <summary>
        /// Updates user
        /// </summary>
        /// <remarks>
        ///     PUT/User/:id
        ///     
        ///     {
        ///        "firstName": "Updated User",
        ///        "lastName": "Updated User LastName",
        ///        "email": "updated@gmail.com",
        ///        "phoneNumber": "578894568"
        ///     }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>Updated user's data</returns>
        /// <response code="200">Returns the newly created user's data</response>
        [ProducesResponseType(typeof(UserResponseModel), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseModel>> Put(CancellationToken cancellationToken, UpdateUserRequestModel request, int id)
        {
            return Ok(await _service.UpdateAsync(cancellationToken, request, id));
        }
        /// <summary>
        /// Deletes user
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
            return NoContent();
        }
    }
}
