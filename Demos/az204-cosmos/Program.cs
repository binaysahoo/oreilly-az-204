using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

// NEVER hardcode these values!
string? endpoint = "https://az204-or-demo-cosmos.documents.azure.com:443/";

// NEVER hardcode these values!
string? key = "[cosmos key]";

Console.Write("Database name: ");
string? databaseName = Console.ReadLine();

Console.Write("Container name: ");
string? containerName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(endpoint) ||
    string.IsNullOrWhiteSpace(key) ||
    string.IsNullOrWhiteSpace(databaseName) ||
    string.IsNullOrWhiteSpace(containerName))
{
    Console.WriteLine("All values are required.");
    return;
}

CosmosClient client = new(endpoint, key);

Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
Container container = await database.CreateContainerIfNotExistsAsync(
    id: containerName,
    partitionKeyPath: "/id");

Console.Write("Name: ");
string? name = Console.ReadLine();

Console.Write("Email: ");
string? email = Console.ReadLine();

if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
{
    Console.WriteLine("Name and email are required.");
    return;
}

UserRecord record = new()
{
    Id = email,
    Name = name,
    Email = email
};

ItemResponse<UserRecord> response = await container.UpsertItemAsync(
    record,
    new PartitionKey(record.Id));

Console.WriteLine();
Console.WriteLine($"Record inserted/upserted successfully. Status code: {response.StatusCode}");

public class UserRecord
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;
}
