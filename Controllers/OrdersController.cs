using Microsoft.AspNetCore.Mvc;

namespace SmartMES.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Orders";
        return View();
    }
}
