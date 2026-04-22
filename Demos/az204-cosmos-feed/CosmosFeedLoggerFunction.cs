using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace az204_cosmos_feed;

public class CosmosFeedLoggerFunction
{
    private readonly ILogger<CosmosFeedLoggerFunction> _logger;

    public CosmosFeedLoggerFunction(ILogger<CosmosFeedLoggerFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(CosmosFeedLoggerFunction))]
    public void Run(
        [CosmosDBTrigger(
            databaseName: "%CosmosDbDatabaseName%",
            containerName: "%CosmosDbContainerName%",
            Connection = "CosmosDbConnection",
            LeaseContainerName = "leases",
            CreateLeaseContainerIfNotExists = true)]
        IEnumerable<ChangeFeedDocument> documents)
    {
        foreach (ChangeFeedDocument document in documents)
        {
            string json = JsonSerializer.Serialize(document, new JsonSerializerOptions
            {
                WriteIndented = false
            });

            _logger.LogInformation("Cosmos DB change detected. New document JSON: {DocumentJson}", json);
        }
    }
}
