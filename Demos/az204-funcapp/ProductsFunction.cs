using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace az204_funcapp;

public class ProductsFunction
{
    [Function(nameof(ProductsFunction))]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequestData req)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);

        var items = new[]
        {
            new { id = 1, name = "Item A", price = 10.50 },
            new { id = 2, name = "Item B", price = 20.00 },
            new { id = 3, name = "Item C", price = 30.75 }
        };

        await response.WriteAsJsonAsync(items);
        return response;
    }
}
