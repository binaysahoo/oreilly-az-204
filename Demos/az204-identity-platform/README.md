# az204-identity-platform

ASP.NET Core 8 MVC web app with Microsoft Identity Platform authentication.

## What it does

- Shows a home page with Sign in / Sign out links
- Uses Microsoft Identity Platform for authentication
- Includes a secure page that requires sign-in
- Displays the authenticated user's claims

## Required setup

Register an app in Microsoft Entra ID and update `appsettings.json`:

- `TenantId`
- `ClientId`
- `ClientSecret`
- `Domain`

Also add this redirect URI in the app registration:

```text
https://localhost:7123/signin-oidc
```

## Run

```bash
dotnet restore
dotnet run
```
