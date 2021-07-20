using IO.Ably;

namespace AblyExtension
{
    public interface IAblyClientFactory
    {
        IRestClient CreateClient(string apiKey);
    }
}
