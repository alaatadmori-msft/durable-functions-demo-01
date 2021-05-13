using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionsDemo01
{
    public static class StarterFunction
    {
        [FunctionName("OrchestratorStarterFunction")]
        public static async Task<IActionResult> HttpStart(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest request,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string name = request.GetQueryParameterDictionary()["name"];

            string instanceId = await starter.StartNewAsync("OrchestratorFunction", null, name);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");

            // return new OkResult(); 
            return starter.CreateCheckStatusResponse(request, instanceId);
        }
    }
}