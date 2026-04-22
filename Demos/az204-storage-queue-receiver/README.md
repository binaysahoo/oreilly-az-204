# az204-storage-queue-receiver

A .NET 8 console app that listens to an Azure Storage queue and prints messages.

## What it does

- Prompts for a storage account connection string
- Prompts for a queue name
- Creates the queue if it does not exist
- Polls the queue continuously
- Prints each received message
- Deletes the message after reading it

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
