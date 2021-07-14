using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.DependencyInjection;

namespace AblyExtension
{
    public static class AblyWebjobsBuilderExtensions
    {
        public static IWebJobsBuilder AddAbly(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<AblyBindingConfigProvider>();
            builder.Services.AddSingleton<IAblyClientFactory, AblyClientFactory>();

            return builder;
        }
    }
}
