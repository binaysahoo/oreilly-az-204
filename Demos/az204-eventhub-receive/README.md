# az204-eventhub-receive

A .NET 8 Azure Functions isolated worker app that receives Event Hubs messages.

## What it does

- Uses an Event Hub trigger
- Runs whenever new events arrive
- Logs each event JSON payload to the function logger

## Required setup

Update `local.settings.json`:

- `EventHubConnection`
- `EventHubName`

If running locally, you also need storage for the Functions host:
- start Azurite, or
- replace `AzureWebJobsStorage` with a real storage connection string

## Run

```bash
dotnet restore
dotnet build
func start
```
