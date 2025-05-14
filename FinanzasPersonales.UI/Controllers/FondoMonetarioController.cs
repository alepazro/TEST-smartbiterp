using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.UI.Controllers
{
    public class FondoMonetarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
