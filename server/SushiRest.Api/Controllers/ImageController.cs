using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiRest.Api.Entities;
using SushiRest.Api.Models;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //private static string? _uploadsPath;
        private readonly ILogger<ImageController> _logger;
        private readonly IImageRepository _repository;

        public ImageController(
            IImageRepository imageRepository,
            ILogger<ImageController> logger)
        {
            _repository = imageRepository;
            _logger = logger;
        }
        /// <summary>
        /// Uploads image to the Web API
        /// </summary>
        /// <param name="file">Accepts image file from form request</param>
        /// <returns>Created image file</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(DbImage))]
        [ProducesResponseType(StatusCodes.Status413RequestEntityTooLarge, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UploadImage(
            [FromForm] FileToUpload file
        )
        {
            try
            {
                var image = await _repository.UploadImageAsync(file);
                if (image == null)
                    return BadRequest("Image is null. Something went wrong.");
                var imageUri = new Uri($"/api/image/{image.Name}");
                _logger.LogInformation($"Image uploaded \"{imageUri.LocalPath}\"");
                return Created(imageUri,image);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Gets image from Web API by its name
        /// </summary>
        /// <param name="name">Name of the image</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetImageByName(
            string name
        )
        {
            try
            {
                var dbImage = await _repository.GetImageAsync(name);
                if (dbImage == null) return NotFound();
                var image = await _repository.LoadImageAsync(dbImage)!;
                if (image == null) return NotFound();
                return File(image, $"image/{dbImage.Extension}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Gets image from Web API by its GUID
        /// </summary>
        /// <param name="guid">GUID of the image</param>
        /// <returns></returns>
        [HttpGet("{guid:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FileContentResult))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetImageByGuid(
            Guid guid
        )
        {
            try
            {
                var dbImage = await _repository.GetImageAsync(guid);
                if (dbImage == null) return NotFound();
                var image = await _repository.LoadImageAsync(dbImage)!;
                if (image == null) return NotFound();
                return File(image, $"image/{dbImage.Extension}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}