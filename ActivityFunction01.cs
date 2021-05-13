using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace DurableFunctionsDemo01
{
    public static class ActivityFunction01
    {

        [FunctionName("HelloWorldActivityFunction01")]
        public static string HelloWorldActivityFunction01([ActivityTrigger] string name, ILogger log)
        {
            log.LogInformation($"ActivityFunction01 is running.");
            return "@" + DateTime.Now.ToString("hh: mm: ss") + $" I'm ActivityFunction01, i recieved an input from querystring: {name}.";
        }
    }
}