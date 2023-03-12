using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Application.Addresses;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _service;

        public AddressController(IAddressService addressService)
        {
            _service = addressService;
        }
        /// <summary>
        /// Returns address by id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>Specific address</returns>
        /// <response code="200">Returns the specific address data</response>
        /// <response code="404">If the address was not found</response>
        [ProducesResponseType(typeof(AddressResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }
        /// <summary>
        /// Returns list of addresses
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of addresses</returns>
        /// <response code="200">Returns list of addresses</response>
        [ProducesResponseType(typeof(IEnumerable<AddressResponseModel>),StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressExamples))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AddressResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }
        /// <summary>
        /// Creates new address
        /// </summary>
        ///<remarks>
        /// Note id is not required
        ///
        ///         POST/Address
        ///     
        ///         {
        ///             "userId":1,
        ///             "city": "თბილისი",
        ///             "coutry": "საქართველო",
        ///             "region": "თბილისი",
        ///             "description": "აღწერა..."
        ///         }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <response code="200">Returns newly created address data</response>
        /// <response code="404">If the corresponding user was not found</response>
        /// <returns>Newly created address data</returns>
        [ProducesResponseType(typeof(AddressResponseModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<AddressResponseModel>> Post(CancellationToken cancellationToken, AddressRequestModel request)
        {
            return Ok(await _service.CreateAsync(cancellationToken, request));
        }
        /// <summary>
        /// Updates a specific address
        /// </summary>
        ///<remarks>
        ///Note id is required
        ///
        ///         PUT/Address
        ///     
        ///         {
        ///             "userId":2,
        ///             "city": "Prague",
        ///             "coutry": "Czech Republic",
        ///             "region": "Region",
        ///             "description": "Desc..."
        ///         }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>Updated user data</returns>
        /// <response code="200">Returns updated address data</response>
        /// <response code="404">If the corresponding user was not found</response>
        /// <returns>Updated address data</returns>
        [ProducesResponseType(typeof(AddressResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressResponseModel>> Put(int id,CancellationToken cancellationToken, AddressRequestModel request)
        {
            return Ok(await _service.UpdateAsync(cancellationToken, request, id));
        }
        /// <summary>
        /// Deletes a specific address
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="204">If the user was successfully deleted</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
            return NoContent();
        }
    }
}
