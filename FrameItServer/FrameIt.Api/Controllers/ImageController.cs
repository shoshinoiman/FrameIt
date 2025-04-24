using FrameIt.Core.Dto;
using FrameIt.Core.Services;
using FrameIt.service;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrameIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // הוספת תמונה לקולאז'
        [HttpPost("collage/{collageId}/image")]
        public async Task<IActionResult> AddImage(int collageId, [FromBody] ImageItemDto imageItemDto)
        {
            var result = await _imageService.AddImageToCollageAsync(collageId, imageItemDto);
            if (result == null)
                return NotFound("collage not found");
            return Ok(new { Result = result, Massage = "✅ Well done! Your action was successful. Wishing you continued success!" });
        }

        // עדכון תמונה
        [HttpPut("image/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromBody] ImageItemDto imageItemDto)
        {
            var result = await _imageService.UpdateImageAsync(imageId, imageItemDto);
            if (result == null)
                return NotFound("image not found");

            return Ok(new { Result = result, Massage = "✅ Well done! Your action was successful. Wishing you continued success!" });
        }

        // מחיקת תמונה
        [HttpDelete("image/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            await _imageService.DeleteImageAsync(imageId);
            return NoContent();
        }
    }
}