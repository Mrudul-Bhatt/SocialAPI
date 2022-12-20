using Microsoft.AspNetCore.Mvc;

namespace SocialAPI.Controllers;

public class ErrorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}