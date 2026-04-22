using Azure.Storage.Queues;

// NEVER hardcode these!
string? connectionString = "[storage account connection string]";

// NEVER hardcode these!
string? queueName = "message-queue";

Console.Write("Message text: ");
string? messageText = Console.ReadLine();

if (string.IsNullOrWhiteSpace(connectionString) ||
    string.IsNullOrWhiteSpace(queueName) ||
    string.IsNullOrWhiteSpace(messageText))
{
    Console.WriteLine("Connection string, queue name, and message text are required.");
    return;
}

queueName = queueName.Trim().ToLowerInvariant();

QueueClient queueClient = new(connectionString, queueName);

await queueClient.CreateIfNotExistsAsync();
await queueClient.SendMessageAsync(messageText);

Console.WriteLine($"Message added to queue '{queueName}'.");
