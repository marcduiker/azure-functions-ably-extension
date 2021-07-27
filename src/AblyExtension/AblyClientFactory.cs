using IO.Ably;

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
