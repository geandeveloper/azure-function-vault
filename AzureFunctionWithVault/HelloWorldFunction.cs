using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunctionWithVault
{
    public static class HellowWorldFunction
    {
        [FunctionName(nameof(HellowWorldFunction))]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var connectionString =  Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.Process);
            string responseMessage = $"Hello World the connectionString is {connectionString}";

            return new OkObjectResult(responseMessage);
        }
    }
}
