using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_AzureFunciton_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly HttpClient _httpclient;
        private readonly IConfiguration _configuration;
        public EmployeeController(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpclient = httpClient;
            _configuration = configuration;
        }
        [HttpGet("hello-function")]
        public async Task<IActionResult> callFunction()
        {
            var functionUrl = _configuration["AzureFunctionUrl"];
            var functionKey = _configuration["AzureFunctionKey"];
            var request = new HttpRequestMessage(HttpMethod.Get, functionUrl);

            if (!string.IsNullOrEmpty(functionKey))
            {
                request.Headers.Add("x-functions-key", functionKey);
            }

            var response = await _httpclient.SendAsync(request);

            var result = await response.Content.ReadAsStringAsync();

            return StatusCode((int)response.StatusCode, result);
        }
    //[HttpPost("Upload")]
    //public async Task<IActionResult> Upload(IFormFile file)
    //{
    //    if (file == null || file.Length == 0)
    //    {
    //        return BadRequest("Please select a file.");
    //    }

    //    // 2. Get Azure Storage configuration
    //    var connectionString =
    //        _configuration["AzureStorage:ConnectionString"];

    //    var containerName =
    //        _configuration["AzureStorage:ContainerName"];

    //    // 3. Create BlobServiceClient
    //    var blobServiceClient =
    //        new BlobServiceClient(connectionString);

    //    // 4. Get the documents container
    //    var containerClient =
    //        blobServiceClient.GetBlobContainerClient(containerName);

    //    // 5. Create container if it doesn't exist
    //    await containerClient.CreateIfNotExistsAsync();

    //    // 6. Create a BlobClient for the uploaded file
    //    var blobClient =
    //        containerClient.GetBlobClient(file.FileName);

    //    // 7. Upload file
    //    using var stream = file.OpenReadStream();

    //    await blobClient.UploadAsync(
    //        stream,
    //        overwrite: true);

    //    // 8. Return success
    //    return Ok(new
    //    {
    //        Message = "File uploaded successfully",
    //        FileName = file.FileName
    //    });
    //}
    //[HttpPost("Upload")]
    //public IActionResult Upload([FromForm] IFormFile file)
    //{
    //  if (file == null)
    //  {
    //    return BadRequest("FILE IS NULL");
    //  }

    //  if (file.Length == 0)
    //  {
    //    return BadRequest("FILE IS EMPTY");
    //  }

    //  return Ok(new
    //  {
    //    Message = "File received successfully",
    //    FileName = file.FileName,
    //    Length = file.Length,
    //    ContentType = file.ContentType
    //  });
    //}
    [HttpPost("Upload")]
    public IActionResult Upload()
    {
      return Ok("UPLOAD METHOD REACHED");
    }
  }
}
