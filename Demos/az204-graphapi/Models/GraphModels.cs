using System.Text.Json.Serialization;

namespace az204_graphapi.Models;

public class GraphPageViewModel
{
    public string? UserName { get; set; }
    public string? UserDisplayName { get; set; }
    public string? UserPrincipalName { get; set; }
    public string? ErrorMessage { get; set; }
    public List<GraphDriveItem> Items { get; set; } = [];
}

public class GraphUser
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}

public class GraphDriveItemsResponse
{
    [JsonPropertyName("value")]
    public List<GraphDriveItem> Value { get; set; } = [];
}

public class GraphDriveItem
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("webUrl")]
    public string? WebUrl { get; set; }

    [JsonPropertyName("size")]
    public long? Size { get; set; }

    [JsonPropertyName("lastModifiedDateTime")]
    public DateTimeOffset? LastModifiedDateTime { get; set; }

    [JsonPropertyName("folder")]
    public GraphFolderFacet? Folder { get; set; }

    [JsonPropertyName("file")]
    public GraphFileFacet? File { get; set; }

    public string ItemType => Folder is not null ? "Folder" : "File";
}

public class GraphFolderFacet
{
    [JsonPropertyName("childCount")]
    public int? ChildCount { get; set; }
}

public class GraphFileFacet
{
    [JsonPropertyName("mimeType")]
    public string? MimeType { get; set; }
}
