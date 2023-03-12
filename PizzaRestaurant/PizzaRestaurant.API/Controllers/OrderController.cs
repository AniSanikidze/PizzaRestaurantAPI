using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.RankHistories.Requests;
using PizzaRestaurant.Application.RankHistories.Responses;
using PizzaRestaurant.Application.RankHistories;
using PizzaRestaurant.Application.Orders;
using PizzaRestaurant.Application.Orders.Responses;
using PizzaRestaurant.Application.Orders.Requests;
using PizzaRestaurant.Application.Addresses.Responses;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService orderService)
        {
            _service = orderService;
        }
        /// <summary>
        /// Returns order based on provided Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>Specific order</returns>
        /// <response code="200">Returns the specific order</response>
        /// <response code="404">If the order was not found</response>
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }
        /// <summary>
        /// Returns list of all orders
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>List of orders</returns>
        /// <response code="200">Returns the list of orders</response>
        [ProducesResponseType(typeof(IEnumerable<OrderResponseModel>), StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderExamples))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderResponseModel>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAllAsync(cancellationToken));
        }
        /// <summary>
        /// Creates an order
        /// </summary>
        /// <remarks>
        /// Note id is not required
        ///
        ///         POST/Order
        ///     
        ///         {
        ///             "pizzaId":1,
        ///             "addressId": 7,
        ///             "userId": 7
        ///         }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>newly created order</returns>
        /// <response code="200">Returns the list of orders</response>
        /// <response code="404">If user,pizza or address was not given correctly</response>
        [ProducesResponseType(typeof(OrderResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<OrderResponseModel>> Post(CancellationToken cancellationToken, OrderRequestModel request)
        {
            return Ok(await _service.CreateAsync(cancellationToken, request));
        }
    }
}
