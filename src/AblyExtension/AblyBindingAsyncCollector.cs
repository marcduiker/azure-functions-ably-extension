using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace AblyExtension
{
    public class AblyBindingAsyncCollector<T> : IAsyncCollector<T>
    {
        private readonly AblyBindingContext _ablyBindingContext;

        public AblyBindingAsyncCollector(AblyBindingContext ablyBindingContext)
        {
            _ablyBindingContext = ablyBindingContext;
        }

        public async Task AddAsync(T item, CancellationToken cancellationToken = default)
        {
            if (item == null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            await _ablyBindingContext.AblyClient.Channels
                .Get(_ablyBindingContext.ResolvedAttribute.Channel)
                .PublishAsync(_ablyBindingContext.ResolvedAttribute.EventName, item);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}
