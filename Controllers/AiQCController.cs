using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class AiQCController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "AI Quality Control";
        return View();
    }
}
