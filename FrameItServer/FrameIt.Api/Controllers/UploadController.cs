// .NET Controller
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class UploadController : ControllerBase
{
    private readonly IAmazonS3 _s3Client;

    public UploadController(IAmazonS3 s3Client)
    {
        _s3Client = s3Client;
    }

    [HttpGet("presigned-url")]
    public async Task<IActionResult> GetPresignedUrl([FromQuery] string fileName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = "my-collages",
            Key = fileName,
            Verb = HttpVerb.PUT,
            Expires = DateTime.UtcNow.AddMinutes(500),
            ContentType = "image/png" 
        };

        string url = _s3Client.GetPreSignedURL(request);
        return Ok(new { url });
    }
    [HttpGet("presigned-get-url")]
    public async Task<IActionResult> GetPresignedImage([FromQuery] string fileName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = "my-collages",
            Key = fileName,
            Verb = HttpVerb.GET,
            Expires = DateTime.UtcNow.AddMinutes(500),
        };

        string url = _s3Client.GetPreSignedURL(request);
        return Ok(new { url });
    }

    [HttpGet("presigned-delete-url")]
    public async Task<IActionResult> GetPresignedDeleteUrl([FromQuery] string fileName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = "my-collages",
            Key = fileName,
            Verb = HttpVerb.DELETE,
            Expires = DateTime.UtcNow.AddMinutes(500)
        };

        string url = _s3Client.GetPreSignedURL(request);
        return Ok(new { url });
    }
}


