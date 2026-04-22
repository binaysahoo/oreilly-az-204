using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

// NEVER hardcode these!
string? connectionString = "[storage account connection string]";

// NEVER hardcode these!
string? queueName = "message-queue";

if (string.IsNullOrWhiteSpace(connectionString) ||
    string.IsNullOrWhiteSpace(queueName))
{
    Console.WriteLine("Connection string and queue name are required.");
    return;
}

queueName = queueName.Trim().ToLowerInvariant();

QueueClient queueClient = new(connectionString, queueName);

await queueClient.CreateIfNotExistsAsync();

Console.WriteLine($"Listening to queue '{queueName}'...");
Console.WriteLine("Press Ctrl+C to stop.");

while (true)
{
    QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(
        maxMessages: 1,
        visibilityTimeout: TimeSpan.FromSeconds(30));

    if (messages.Length == 0)
    {
        await Task.Delay(2000);
        continue;
    }

    foreach (QueueMessage message in messages)
    {
        Console.WriteLine();
        Console.WriteLine("Message received:");
        Console.WriteLine(message.MessageText);

        await queueClient.DeleteMessageAsync(
            message.MessageId,
            message.PopReceipt);

        Console.WriteLine("Message deleted from queue.");
    }
}
