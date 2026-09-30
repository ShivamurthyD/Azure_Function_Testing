using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_AzureFunciton_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly HttpClient _httpclient;
        public EmployeeController(HttpClient httpClient)
        {
            this._httpclient = httpClient;
        }
        [HttpGet("hello-function")]
        public async Task<IActionResult> callFunction()
        {
            var respose =await _httpclient.GetAsync("http://localhost:7086/api/HelloFunction");
            var result= await respose.Content.ReadAsStringAsync();
            return Ok(result);
        }
    }
}
