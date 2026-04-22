using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

// NEVER hardcode these values!
string? connectionString = "[storage acocunt connection string]";

Console.Write("Container name: ");
string? containerName = Console.ReadLine();

Console.Write("Blob file name (example: sample.txt): ");
string? blobName = Console.ReadLine();

Console.WriteLine("Enter the text content for the file:");
string? fileContent = Console.ReadLine();

if (string.IsNullOrWhiteSpace(connectionString) ||
    string.IsNullOrWhiteSpace(containerName) ||
    string.IsNullOrWhiteSpace(blobName) ||
    string.IsNullOrWhiteSpace(fileContent))
{
    Console.WriteLine("All values are required.");
    return;
}

BlobServiceClient blobServiceClient = new(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

await containerClient.CreateIfNotExistsAsync();

BlobClient blobClient = containerClient.GetBlobClient(blobName);

byte[] contentBytes = Encoding.UTF8.GetBytes(fileContent);
using MemoryStream stream = new(contentBytes);

Dictionary<string, string> metadata = new()
{
    ["uploadedby"] = "az204-storage",
    ["contenttype"] = "text"
};

BlobHttpHeaders headers = new()
{
    ContentType = "text/plain"
};

await blobClient.UploadAsync(
    content: stream,
    options: new BlobUploadOptions
    {
        HttpHeaders = headers,
        Metadata = metadata
    });

Console.WriteLine();
Console.WriteLine("Upload completed.");
Console.WriteLine("Press Enter to read blob metadata and properties...");
Console.ReadLine();

BlobProperties properties = await blobClient.GetPropertiesAsync();

Console.WriteLine();
Console.WriteLine("Blob properties");
Console.WriteLine($"Name: {blobClient.Name}");
Console.WriteLine($"Blob type: {properties.BlobType}");
Console.WriteLine($"Content type: {properties.ContentType}");
Console.WriteLine($"Content length: {properties.ContentLength}");
Console.WriteLine($"Created on: {properties.CreatedOn}");
Console.WriteLine($"Last modified: {properties.LastModified}");
Console.WriteLine($"ETag: {properties.ETag}");
Console.WriteLine($"Access tier: {properties.AccessTier}");

Console.WriteLine();
Console.WriteLine("Blob metadata");
if (properties.Metadata.Count == 0)
{
    Console.WriteLine("No metadata found.");
}
else
{
    foreach (var item in properties.Metadata)
    {
        Console.WriteLine($"{item.Key}: {item.Value}");
    }
}
