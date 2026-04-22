# az204-storage

A .NET 8 console app that works with Azure Blob Storage.

## What it does

- Prompts for a storage account connection string
- Prompts for a container name
- Prompts for a blob file name
- Prompts for text content
- Creates the container if it does not exist
- Uploads a text file generated in memory
- Waits for user confirmation
- Reads the blob's metadata and properties
- Prints them to the console

## Run

```bash
dotnet restore
dotnet run
```
