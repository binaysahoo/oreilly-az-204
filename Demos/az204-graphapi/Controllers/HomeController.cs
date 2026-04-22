using System.Net.Http.Headers;
using System.Text.Json;
using az204_graphapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;

namespace az204_graphapi.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(
        ITokenAcquisition tokenAcquisition,
        IHttpClientFactory httpClientFactory)
    {
        _tokenAcquisition = tokenAcquisition;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        GraphPageViewModel model = new()
        {
            UserName = User.Identity?.Name
        };

        try
        {
            string[] scopes = ["User.Read", "Files.Read"];
            string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);

            HttpClient client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            using HttpResponseMessage meResponse =
                await client.GetAsync("https://graph.microsoft.com/v1.0/me?$select=displayName,userPrincipalName");

            if (!meResponse.IsSuccessStatusCode)
            {
                model.ErrorMessage = $"Graph /me request failed: {(int)meResponse.StatusCode} {meResponse.ReasonPhrase}";
                return View(model);
            }

            await using (Stream meStream = await meResponse.Content.ReadAsStreamAsync())
            {
                GraphUser? me = await JsonSerializer.DeserializeAsync<GraphUser>(
                    meStream,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                model.UserDisplayName = me?.DisplayName;
                model.UserPrincipalName = me?.UserPrincipalName;
            }

            using HttpResponseMessage driveResponse =
                await client.GetAsync("https://graph.microsoft.com/v1.0/me/drive/root/children?$top=10&$select=name,webUrl,size,lastModifiedDateTime,folder,file");

            if (!driveResponse.IsSuccessStatusCode)
            {
                string errorBody = await driveResponse.Content.ReadAsStringAsync();
                model.ErrorMessage = $"Graph Drive request failed: {(int)driveResponse.StatusCode} {driveResponse.ReasonPhrase}. Response: {errorBody}";
                return View(model);
            }

            await using Stream driveStream = await driveResponse.Content.ReadAsStreamAsync();

            GraphDriveItemsResponse? result = await JsonSerializer.DeserializeAsync<GraphDriveItemsResponse>(
                driveStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            model.Items = result?.Value ?? [];
        }
        catch (Exception ex)
        {
            model.ErrorMessage = ex.Message;
        }

        return View(model);
    }
}
