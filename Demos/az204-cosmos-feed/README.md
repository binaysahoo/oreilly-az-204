# az204-cosmos-feed

.NET 8 Azure Functions isolated worker project that uses a Cosmos DB change feed trigger.

## What it does

- Watches a Cosmos DB for NoSQL container
- Triggers on inserts and updates
- Logs the new JSON document value for each changed item

## Key settings

Update `local.settings.json` with your values:

- `AzureWebJobsStorage`
- `CosmosDbConnection`
- `CosmosDbDatabaseName`
- `CosmosDbContainerName`

## Notes

- The trigger uses a lease container named `leases`
- `CreateLeaseContainerIfNotExists = true` lets the function create the lease container automatically
- Cosmos DB change feed captures inserts and updates, not deletes

## Run

```bash
dotnet restore
dotnet build
func start
```
