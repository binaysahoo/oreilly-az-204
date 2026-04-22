using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace az204_eventhub_receive;

public class EventHubReceiverFunction
{
    private readonly ILogger<EventHubReceiverFunction> _logger;

    public EventHubReceiverFunction(ILogger<EventHubReceiverFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(EventHubReceiverFunction))]
    public void Run(
        [EventHubTrigger("%EventHubName%", Connection = "EventHubConnection")] string[] events)
    {
        foreach (string eventJson in events)
        {
            _logger.LogInformation("Received Event Hub event: {EventJson}", eventJson);
        }
    }
}
