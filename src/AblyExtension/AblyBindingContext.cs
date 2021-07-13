using IO.Ably;

namespace AblyExtension
{
    public class AblyBindingContext
    {
        public AblyAttribute ResolvedAttribute { get; set; }

        public AblyRealtime AblyClient { get; set; }
    }
}
