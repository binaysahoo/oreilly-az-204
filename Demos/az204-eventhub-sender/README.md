# az204-eventhub-sender

A .NET 8 console app that sends 500 events to Azure Event Hubs.

## What it does

- Prompts for an Event Hubs namespace connection string
- Prompts for an Event Hub name
- Creates 500 sample JSON events
- Sends them in batches to Azure Event Hubs

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
