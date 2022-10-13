using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SampleFunction
{
    public class SampleFunction
    {
        [FunctionName(nameof(SampleFunction))]
        public async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = !string.IsNullOrEmpty(req.Query["name"]) ? req.Query["name"] : "World";

            string responseMessage = $"Hello {name}. UTC Time: {DateTime.UtcNow}";

            return new OkObjectResult(responseMessage);
        }
    }
}
