# az204-keyvault

A .NET 8 console app that reads a secret from Azure Key Vault and prints it to the console.

## What it does

- Connects to the Key Vault named `az204-ordemo-kv`
- Reads the secret named `myPassword`
- Prints the secret name and value

## Authentication

This sample uses `DefaultAzureCredential`, so one of these should be available:

- Azure CLI login
- Visual Studio / Visual Studio Code signed-in account
- Environment variables for a service principal
- Managed identity

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
