using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class CostAnalyticsController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Cost Analytics";
        return View();
    }
}
