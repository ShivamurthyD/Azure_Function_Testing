using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Functions
{
    public class BlobTriggerFunction
    {
        private readonly ILogger<BlobTriggerFunction> _logger;

        public BlobTriggerFunction(ILogger<BlobTriggerFunction> logger)
        {
            _logger = logger;
        }

        [Function("BlobTriggerFunction")]
        public void Run(
            [BlobTrigger("documents/{name}",
                Connection = "AzureWebJobsStorage")]
            string blobContent,
            string name)
        {
            _logger.LogInformation(
                "Blob Trigger executed.");

            _logger.LogInformation(
                "File Name: {name}",
                name);

            _logger.LogInformation(
                "File Content: {content}",
                blobContent);
        }
    }
}

