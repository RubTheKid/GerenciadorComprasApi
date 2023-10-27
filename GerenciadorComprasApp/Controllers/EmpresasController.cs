using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApp.Controllers
{
    public class EmpresasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
