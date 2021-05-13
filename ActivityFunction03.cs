using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;

namespace DurableFunctionsDemo01
{
    public static class ActivityFunction03
    {

        [FunctionName("HelloWorldActivityFunction03")]
        public static string HelloWorldActivityFunction03([ActivityTrigger] string input, ILogger log)
        {
            log.LogInformation($"ActivityFunction03 is running.");
            return "@" + DateTime.Now.ToString("hh: mm: ss") + $" I'm ActivityFunction03, i recieved an input from ActivityFunction02: {input}";
        }
    }
}