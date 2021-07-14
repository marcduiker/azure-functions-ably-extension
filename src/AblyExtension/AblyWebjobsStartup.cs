using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

namespace AblyExtension
{
    public class AblyWebjobsStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddAbly();
        }
    }
}
