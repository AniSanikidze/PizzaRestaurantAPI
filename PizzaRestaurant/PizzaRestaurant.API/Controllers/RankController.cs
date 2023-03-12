using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Addresses.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.Application.Addresses;
using PizzaRestaurant.Application.RankHistories;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankController : ControllerBase
    {
        private readonly IRankHistoryService _service;

        public RankController(IRankHistoryService addressService)
        {
            _service = addressService;
        }
        /// <summary>
        /// Returns rank based on provided Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>specific rank</returns>
        /// <response code="200">Returns the specific rank</response>
        /// <response code="404">If the rank was not found</response>
        [ProducesResponseType(typeof(RankHistoryResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<RankHistoryResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }

        /// <summary>
        /// Returns list of all ranks
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of ranks</returns>
        /// <response code="200">Returns the list of orders</response>
        [ProducesResponseType(typeof(IEnumerable<RankHistoryResponseModel>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RankExamples))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RankHistoryResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }
        /// <summary>
        /// Ranks pizza on a scale of 1 to 10
        /// </summary>
        /// <remarks>
        /// Note id is not required
        ///
        ///         POST/Rank
        ///     
        ///         {
        ///             "pizzaId":1,
        ///             "rank": 7,
        ///             "userId": 7
        ///         }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>newly created rank</returns>
        /// <response code="200">Successfully ranked pizza</response>
        /// <response code="404">If the user or pizza was not found </response>
        /// <response code="400">If the user has not order the pizza</response>
        [ProducesResponseType(typeof(RankHistoryResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<RankHistoryResponseModel>> Post(CancellationToken cancellationToken, RankHistoryRequestModel request)
        {
            return Ok(await _service.CreateAsync(cancellationToken, request));
        }
    }
}
