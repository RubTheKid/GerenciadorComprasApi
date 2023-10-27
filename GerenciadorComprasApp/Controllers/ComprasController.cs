using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApp.Controllers;

public class ComprasController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
