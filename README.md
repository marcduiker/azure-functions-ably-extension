# Azure Functions Ably Extension

This Azure Functions binding allows you to easily publish messages to [Ably](https://ably.com/), an awesome realtime messaging system available for you in the cloud.

## Usage for .NET Core

Add the `Ably.Azure.Functions.Extensions` NuGet package to your project.

### IAsyncCollector for .NET Core

To publish a collection of messages use the following output binding:

```csharp
[Ably("%AblyApiKey%", "%AblyChannel%", "%AblyEventName%")] IAsyncCollector<T> collector,
```

Here, the binding is used in an HTTP trigger function that contains an array of `EventData` objects in the request body.

```csharp
[FunctionName(nameof(AblyAsyncCollectorTest))]
public static async Task<IActionResult> RunAsync(
    [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] EventData[] eventDataCollection,
    [Ably("%AblyApiKey%", "%AblyChannel%", "%AblyEventName%")] IAsyncCollector<EventData> collector,
    ILogger log)
{
    foreach (var eventData in eventDataCollection)
    {
        await collector.AddAsync(eventData);
    }

    return new AcceptedResult();
}
```
