﻿using System;
using IO.Ably;
using Microsoft.Azure.WebJobs.Description;

namespace AblyExtension
{

    public class AblyClientFactory : IAblyClientFactory
    {
        public IRestClient CreateClient(string apiKey)
        {
            return new AblyRest(apiKey);
        }
    }
}
