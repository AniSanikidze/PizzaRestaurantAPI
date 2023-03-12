using Microsoft.AspNetCore.Mvc;
using PizzaRestaurant.Application.Images;
using PizzaRestaurant.Application.Images.Responses;
using PizzaRestaurant.Application.Images.Requests;
using PizzaRestaurant.API.Infrastructure.SwagExamples;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaRestaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _service;

        public ImageController(IImageService addressService)
        {
            _service = addressService;
        }
        /// <summary>
        /// Returns image based on Id
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="id"></param>
        /// <returns>Specific image by id</returns>
        /// <response code="200">Returns the specific image data</response>
        /// <response code="404">If the image was not found</response>
        [ProducesResponseType(typeof(ImageResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageResponseModel>> Get(CancellationToken cancellationToken, int id)
        {
            return Ok(await _service.GetAsync(cancellationToken, id));
        }
        /// <summary>
        /// Returns all images
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>specific lits of images</returns>
        /// <response code="200">Returns the list of images</response>
        [ProducesResponseType(typeof(IEnumerable<ImageResponseModel>),StatusCodes.Status200OK)]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(ImageResponseExamples))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<IEnumerable<ImageResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync(cancellationToken);
        }
        /// <summary>
        /// Creates an image
        /// </summary>
        /// <remarks>
        /// Note id is not required
        ///
        ///         POST/Image
        ///     
        ///         {
        ///             "pizzaId":1,
        ///             "originalName": "Image1",
        ///             "path": "Image1Path"
        ///         }
        /// </remarks>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns>Returns newly created image</returns>
        /// <response code="200">Returns the newly created image</response>
        [ProducesResponseType(typeof(ImageResponseModel), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<ImageResponseModel>> Post(CancellationToken cancellationToken, ImageRequestModel request)
        {
            return Ok(await _service.CreateAsync(cancellationToken, request));
        }
    }
}
