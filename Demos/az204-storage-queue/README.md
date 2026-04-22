# az204-storage-queue

A .NET 8 console app that takes a message from the user and sends it to an Azure Storage queue.

## What it does

- Prompts for a storage account connection string
- Prompts for a queue name
- Prompts for a message text
- Creates the queue if it does not exist
- Sends the message to the queue

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
