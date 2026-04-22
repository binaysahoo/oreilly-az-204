using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using az204_keyvault_reference.Models;

namespace az204_keyvault_reference.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;
    private readonly TelemetryClient _telemetryClient;

    public HomeController(IConfiguration configuration, TelemetryClient telemetryClient)
    {
        _configuration = configuration;
        _telemetryClient = telemetryClient;
    }

    public IActionResult Index()
    {
        _telemetryClient.TrackEvent("HomePageViewed");

        HomeViewModel model = new()
        {
            SettingKey = "storageConnection",
            SettingValue = _configuration["storageConnection"] ?? "(not found)"
        };

        return View(model);
    }
}