# az204-graphapi

ASP.NET Core 8 MVC web app that demonstrates calling Microsoft Graph in code.

## Example used

This sample:
- signs the user in with Microsoft Entra ID
- gets the signed-in user's profile from Microsoft Graph
- gets the first 10 items from the signed-in user's OneDrive root folder
- prints the results on the default page

This is a good delegated-permissions Graph example because it is simple, useful, and easy to understand in code.

## Required setup

1. Create a web app registration in Microsoft Entra ID.
2. Add this redirect URI:
   `https://localhost:7171/signin-oidc`
3. In **API permissions**, add delegated Microsoft Graph permissions:
   - `User.Read`
   - `Files.Read`
4. Grant consent if required by your tenant.
5. Update `appsettings.json`:
   - `AzureAd:Domain`
   - `AzureAd:TenantId`
   - `AzureAd:ClientId`
   - `AzureAd:ClientSecret`

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
