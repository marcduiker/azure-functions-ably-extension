using System;
using IO.Ably;
using Microsoft.Azure.WebJobs.Description;

namespace AblyExtension
{

    public class AblyClientFactory : IAblyClientFactory
    {
        public AblyRealtime CreateClient(string apiKey)
        {
            return new AblyRealtime(apiKey);
        }
    }
}
