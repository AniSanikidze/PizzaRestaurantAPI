using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Users.Requests;
using PizzaRestaurant.Application.Users.Responses;
using PizzaRestaurant.Application.Users;
using PizzaRestaurant.Application.Pizzas;
using PizzaRestaurant.Application.Pizzas.Responses;
using PizzaRestaurant.Application.Pizzas.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _service;

        public PizzaController(IPizzaService userService)
        {
            _service = userService;
        }
        /// <summary>
        /// Returns pizza based on id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>Return specific pizza</returns>
        /// <response code="200">Returns the specific pizza data</response>
        /// <response code="404">If the pizza was not found</response>
        [ProducesResponseType(typeof(PizzaResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }
        /// <summary>
        /// Returns list of pizzas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>list of pizzas</returns>
        [ProducesResponseType(typeof(IEnumerable<PizzaResponseModel>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaExamples))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }
        /// <summary>
        /// Creates a pizza
        /// </summary>
        /// <remarks>
        /// Note id is not required
        ///
        ///         POST/Pizza
        ///     
        ///             {
        ///                 "name": "New Pizza",
        ///                 "description": "New pizza desc",
        ///                 "price": 20,
        ///                 "caloryCount": 300
        ///             }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>newly created pizza</returns>
        /// <response code="200">Returns newly created pizza</response>
        [ProducesResponseType(typeof(PizzaResponseModel), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<int>> Post(CancellationToken cancellationToken, PizzaRequestModel request)
        {
           return Ok(await _service.CreateAsync(cancellationToken, request));
        }
        /// <summary>
        /// Updates a specific pizza
        /// </summary>
        /// <remarks>
        /// Note id is required
        ///
        ///         POST/Pizza
        ///     
        ///             {
        ///                 "name": "Updated Pizza",
        ///                 "description": "Updated pizza desc",
        ///                 "price": 25,
        ///                 "caloryCount": 350
        ///             }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <param name="id"></param>
        /// <returns>Updated Pizza data</returns>
        /// <response code="200">Returns updated pizza</response>
        [ProducesResponseType(typeof(PizzaResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<ActionResult<PizzaResponseModel>> Put(CancellationToken cancellationToken, PizzaRequestModel request, int id)
        {
            return Ok(await _service.UpdateAsync(cancellationToken, request,id));
        }
        /// <summary>
        /// Deletes a pizza based on Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>No content</returns>
        /// <response code="204">If pizza was successfully deleted</response>
        /// <response code="404">If pizza was not found</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(CancellationToken cancellationToken, int id)
        {
            await _service.DeleteAsync(cancellationToken, id);
            return NoContent();
        }
    }
}
