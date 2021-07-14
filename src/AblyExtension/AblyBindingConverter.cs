using Microsoft.Azure.WebJobs;

namespace AblyExtension
{
    public class AblyBindingConverter<T> : IConverter<AblyAttribute, IAsyncCollector<T>>
    {
        private readonly AblyBindingConfigProvider _configProvider;

        public AblyBindingConverter(AblyBindingConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public IAsyncCollector<T> Convert(AblyAttribute attribute)
        {
            AblyBindingContext context = _configProvider.CreateContext(attribute);

            return new AblyBindingAsyncCollector<T>(context);
        }
    }
}
