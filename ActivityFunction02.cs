using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;

namespace DurableFunctionsDemo01
{
    public static class ActivityFunction02
    {

        [FunctionName("HelloWorldActivityFunction02")]
        public static string HelloWorldActivityFunction02([ActivityTrigger] string input, ILogger log)
        {
            log.LogInformation($"ActivityFunction02 is running.");
            return "@" + DateTime.Now.ToString("hh: mm: ss") + $" I'm ActivityFunction02, i recieved an input from ActivityFunction01: {input}";
        }
    }
}