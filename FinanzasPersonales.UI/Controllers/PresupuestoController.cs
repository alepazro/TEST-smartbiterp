using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasPersonales.UI.Controllers
{
    public class PresupuestoController : Controller
    {
        // GET: PresupuestoController
        public ActionResult Index(int usuario, int mes)
        {
            return View();
        }

        
    }
}
