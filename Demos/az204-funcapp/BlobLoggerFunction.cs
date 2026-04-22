using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.IO;

namespace az204_funcapp;

public class BlobLoggerFunction
{
    private readonly ILogger<BlobLoggerFunction> _logger;

    public BlobLoggerFunction(ILogger<BlobLoggerFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(BlobLoggerFunction))]
    public void Run(
        [BlobTrigger("images/{name}", Connection = "TriggerStorage")] Stream blob,
        string name)
    {
        _logger.LogInformation("Blob uploaded: {BlobName}", name);
    }
}