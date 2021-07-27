using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using AblyExtension;

namespace AblyDemo
{
    public static class AblyAsyncCollectorTest
    {
        [FunctionName(nameof(AblyAsyncCollectorTest))]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] EventData[] eventDataCollection,
            [Ably("%AblyApiKey%", "%AblyChannel%", "%AblyEventName%")] IAsyncCollector<EventData> collector,
            ILogger log)
        {

            foreach (var eventData in eventDataCollection)
            {
                await collector.AddAsync(eventData);
            }
            
            return new AcceptedResult();
        }
    }
}
