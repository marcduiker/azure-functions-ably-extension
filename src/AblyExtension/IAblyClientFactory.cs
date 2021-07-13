using IO.Ably;

namespace AblyExtension
{
    public interface IAblyClientFactory
    {
        AblyRealtime CreateClient(string apiKey);
    }
}
