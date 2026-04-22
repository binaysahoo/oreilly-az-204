# az204-keyvault-reference

ASP.NET Core 8 MVC web app that reads a configuration app setting from `appsettings.json`
and shows its value on the default page.

## What it does

- Uses MVC
- Reads the `storageConnection` setting from configuration
- Shows the setting key and value on the default view
- Writes a startup trace entry to Application Insights
- No authentication

## Setup

Update `appsettings.json` with your Application Insights connection string.

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
