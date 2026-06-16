using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class RBACController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Access Control";
        return View();
    }
}
