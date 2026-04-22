# az204-cosmos

A .NET 8 console application for Azure Cosmos DB for NoSQL.

## What it does

- Prompts for Cosmos DB endpoint and key
- Prompts for database name and container name
- Creates the database if it does not exist
- Creates the container if it does not exist
- Prompts for a user's name and email
- Upserts a document where:
  - `id` = email
  - partition key path = `/id`

## Run

```bash
dotnet restore
dotnet run
```
