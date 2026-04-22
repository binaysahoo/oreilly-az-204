# az204-entra

ASP.NET Core 8 MVC web app that authenticates users with Microsoft Entra ID.

## What it does

- Shows a home page with a sign-in link
- Uses Microsoft Entra ID through Microsoft Identity Platform
- After sign-in, shows the signed-in user name on the default page
- Includes a profile page that requires authentication

## Required setup

Create an app registration in Microsoft Entra ID, then update `appsettings.json`:

- `Domain`
- `TenantId`
- `ClientId`
- `ClientSecret`

Add this redirect URI in the app registration:

```text
https://localhost:7157/signin-oidc
```

## Run

```bash
dotnet restore
dotnet build
dotnet run
```
