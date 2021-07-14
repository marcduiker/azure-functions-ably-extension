using System;
using Microsoft.Azure.WebJobs.Description;

namespace AblyExtension
{
    [AttributeUsage(AttributeTargets.ReturnValue | AttributeTargets.Parameter)]
    [Binding]
    public class AblyAttribute : Attribute
    {
        public AblyAttribute()
        {
        }

        public AblyAttribute(
            string apiKey,
            string channel,
            string eventName)
        {
            ApiKey = apiKey;
            Channel = channel;
            EventName = eventName;
        }

        [AutoResolve]
        public string ApiKey { get; private set; }

        [AutoResolve]
        public string Channel { get; private set; }

        [AutoResolve]
        public string EventName { get; set; }
    }
}
