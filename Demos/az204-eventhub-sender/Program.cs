using System.Text;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

// NEVER hardcode these!
string? connectionString = "[event hub connecting string]";

// NEVER hardcode these!
string? eventHubName = "events";

if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(eventHubName))
{
    Console.WriteLine("Connection string and Event Hub name are required.");
    return;
}

await using EventHubProducerClient producer = new(connectionString, eventHubName);

List<EventData> allEvents = new();

for (int i = 1; i <= 500; i++)
{
    string payload = $$"""
    {
      "eventNumber": {{i}},
      "message": "Sample event {{i}}",
      "createdUtc": "{{DateTime.UtcNow:O}}"
    }
    """;

    EventData eventData = new(Encoding.UTF8.GetBytes(payload));
    eventData.Properties["source"] = "az204-eventhub-sender";
    eventData.Properties["sequence"] = i;

    allEvents.Add(eventData);
}

int sentCount = 0;
using IEnumerator<EventData> enumerator = allEvents.GetEnumerator();

while (enumerator.MoveNext())
{
    using EventDataBatch batch = await producer.CreateBatchAsync();

    do
    {
        if (!batch.TryAdd(enumerator.Current))
        {
            break;
        }

        sentCount++;
    }
    while (enumerator.MoveNext());

    await producer.SendAsync(batch);
    Console.WriteLine($"Sent batch. Total events sent so far: {sentCount}");
}

Console.WriteLine($"Done. Sent {sentCount} events to Event Hub '{eventHubName}'.");
