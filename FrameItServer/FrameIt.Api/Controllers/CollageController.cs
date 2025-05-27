using FrameIt.Core.Dto;
using FrameIt.Core.Services;
using FrameIt.Data.Items;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrameIt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollageController : ControllerBase
    {
        private readonly ICollageService _collageService;

        public CollageController(ICollageService collageService)
        {
            _collageService = collageService;
        }

        //create new collage 
        [HttpPost("create")]
        public async Task<ActionResult<Collage>> CreateCollage([FromBody] CollageDto collageDto)
        {
            var collage = await _collageService.CreateCollageAsync(collageDto.UserId, collageDto.Title,collageDto.CollageUrl);
            if (collage == null)
                return NotFound("user not found👎🏿");
            return CreatedAtAction(nameof(GetCollageById), new { collageId = collage.Id }, collage);
        }

        //// קבלת כל הקולאז'ים של משתמש
        //[HttpGet("user/{userId}")]
        //public async Task<ActionResult<List<Collage>>> GetCollagesByUser(int userId)
        //{
        //    var collages = await _collageService.GetCollagesByUserAsync(userId);
        //    return Ok(new{Collages=collages, Massage= "✅ Well done! Your action was successful. Wishing you continued success!"});

        //    if (collages == null)
        //        return NotFound("user not found👎🏿");
        //}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<CollageDto>>> GetCollagesByUser(int userId)
        {
            var collages = await _collageService.GetCollagesByUserAsync(userId);

            if (collages == null || !collages.Any())
                return NotFound("user not found 👎🏿");

            return Ok(new
            {
                Collages = collages,
                Message = "✅ Well done! Your action was successful. Wishing you continued success!"
            });
        }


        // קבלת קולאז' לפי מזהה
        [HttpGet("{collageId}")]
        public async Task<ActionResult<Collage>> GetCollageById(int collageId)
        {
            var collage = await _collageService.GetCollageByIdAsync(collageId);
            if (collage == null)
            {
                return NotFound("Collage not found");
            }

            return Ok(new { message = "✅ Well done! Your action was successful. Wishing you continued success!", Collage = collage });
        }


        [HttpDelete("{collageId}")]
        public async Task<IActionResult> DeleteCollage(int collageId)
        {
            var collage = await _collageService.GetCollageByIdAsync(collageId);
            if (collage == null)
                return NotFound("collage not found");
            var success = await _collageService.DeleteCollageAsync(collageId);
            if (!success)
                return NotFound(new { message = "Collage not found" });

            return Ok(new { message = "Collage deleted successfully" });
        }
    }
}
