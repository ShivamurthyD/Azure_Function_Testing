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
    }
}
