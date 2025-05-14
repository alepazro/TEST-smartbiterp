using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.UI.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
