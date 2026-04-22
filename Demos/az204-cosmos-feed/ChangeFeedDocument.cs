using System.Text.Json;
using System.Text.Json.Serialization;

namespace az204_cosmos_feed;

public class ChangeFeedDocument
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }
}
