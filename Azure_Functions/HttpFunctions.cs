using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Functions
{
    public class HttpFunctions
    {
        [Function("HelloFunction")]
        public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")]
        HttpRequestData req,
        [BlobInput("documents/hello.txt",
            Connection = "AzureWebJobsStorage")]
        string blobContent)
        {
            var response = req.CreateResponse(HttpStatusCode.OK);

           await response.WriteStringAsync(blobContent);

            return response;
        }
    }
}
