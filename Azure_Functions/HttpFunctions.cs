using Microsoft.AspNetCore.Http;
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
        public async Task<MultiResponse> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")]
        HttpRequestData req,
        [BlobInput("documents/hello.txt",
            Connection = "AzureWebJobsStorage")]
        string blobContent)
        {
            var updatedContent = "TEST BLOB OUTPUT";
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteStringAsync("File process successfully");


           //await response.WriteStringAsync(blobContent);

            return new MultiResponse
            {
                httpResponse = response,
                outputBlob = updatedContent
            };
        }
    }
    public class MultiResponse
    {
        public HttpResponseData httpResponse { get; set; } = null!;
        [BlobOutput("documents/result.txt",Connection = "AzureWebJobsStorage")]
        public string outputBlob { get; set; } = "";
    }
}
