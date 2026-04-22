# .NET 8 Azure Functions sample

This project contains:
- `TimerLoggerFunction`: timer-triggered function that logs a message every 5 minutes.
- `ProductsFunction`: HTTP-triggered function that returns a dummy JSON array.

## Run locally

Install Azure Functions Core Tools first, then run:

```powershell
func start
```

HTTP endpoint:

```text
GET http://localhost:7071/api/products
```
