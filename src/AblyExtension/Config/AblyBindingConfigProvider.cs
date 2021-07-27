using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;

namespace AblyExtension
{
    public class AblyBindingConfigProvider : IExtensionConfigProvider
    {
        private readonly IAblyClientFactory _ablyClientFactory;
        public AblyBindingConfigProvider(IAblyClientFactory ablyClientFactory)
        {
            _ablyClientFactory = ablyClientFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var rule = context.AddBindingRule<AblyAttribute>();
            rule.AddValidator(ValidateAttribute);
            rule.BindToCollector<AblyBindingOpenType>(typeof(AblyBindingConverter<>), this);
        }

        internal AblyBindingContext CreateContext(AblyAttribute attribute)
        {
            var ablyClient =  _ablyClientFactory.CreateClient(attribute.ApiKey);

            return new AblyBindingContext {
                AblyClient = ablyClient,
                ResolvedAttribute = attribute
            };
        }

        internal void ValidateAttribute(AblyAttribute attribute, Type paramType)
        {
            if (string.IsNullOrEmpty(attribute.ApiKey))
            {
                string attributeProperty = $"{nameof(AblyAttribute)}.{nameof(AblyAttribute.ApiKey)}";
                throw new InvalidOperationException(
                    $"The Ably API key must be set via the {attributeProperty} property.");
            }
            if (string.IsNullOrEmpty(attribute.Channel))
            {
                string attributeProperty = $"{nameof(AblyAttribute)}.{nameof(AblyAttribute.Channel)}";
                throw new InvalidOperationException(
                    $"The Ably channel must be set via the {attributeProperty} property.");
            }
            if (string.IsNullOrEmpty(attribute.EventName))
            {
                string attributeProperty = $"{nameof(AblyAttribute)}.{nameof(AblyAttribute.EventName)}";
                throw new InvalidOperationException(
                    $"The Ably event name must be set via the {attributeProperty} property.");
            }
        }

        private class AblyBindingOpenType : OpenType.Poco
        {
            public override bool IsMatch(Type type, OpenTypeMatchContext context)
            {
                if (type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                {
                    return false;
                }

                if (type.FullName == "System.Object")
                {
                    return true;
                }

                return base.IsMatch(type, context);
            }
        }
    }
}
