using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;

namespace DurableFunctionsDemo01
{
    public static class OrchestratorFunction
    {
        [FunctionName("OrchestratorFunction")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {

            var activityFunction01Output = await context.CallActivityAsync<string>("HelloWorldActivityFunction01", context.GetInput<string>());
            
            var activityFunction02Output = await context.CallActivityAsync<string>("HelloWorldActivityFunction02", activityFunction01Output);
            
            var activityFunction03Output = await context.CallActivityAsync<string>("HelloWorldActivityFunction03", activityFunction02Output);


            return new List<string> {
                activityFunction01Output,
                activityFunction02Output,
                activityFunction03Output};
        }
    }
}