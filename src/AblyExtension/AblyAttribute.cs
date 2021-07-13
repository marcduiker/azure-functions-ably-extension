using System;
using Microsoft.Azure.WebJobs.Description;

namespace AblyExtension
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class AblyAttribute : Attribute
    {
        public AblyAttribute()
        {
        }

        public AblyAttribute(string apiKey, string channel)
        {
            ApiKey = apiKey;
            Channel = channel;
        }

        [AutoResolve]
        public string ApiKey { get; private set; }

        [AutoResolve]
        public string Channel { get; private set; }

        [AutoResolve]
        public string EventName { get; set; }
    }
}
