using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class InventoryController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Inventory";
        return View();
    }
}
