using AblyExtension;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(AblyWebjobsStartup))]
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
