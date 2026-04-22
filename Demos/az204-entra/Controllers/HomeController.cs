using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace az204_entra.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult Profile()
    {
        return View();
    }
}
