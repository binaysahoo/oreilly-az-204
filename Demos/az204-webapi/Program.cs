var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () =>
{
    return Results.Json(new
    {
        message = "Hello from my dummy API",
        success = true,
        date = DateTime.Now,
        items = new[]
        {
            new { id = 1, name = "Apple", price = 2.99 },
            new { id = 2, name = "Orange", price = 3.49 },
            new { id = 3, name = "Banana", price = 1.99 }
        }
    });
});

app.Run();