using Microsoft.AspNetCore.Mvc;

namespace PoliceData.Controllers
{
    public class VerbaleController : Controller
    {
        public IActionResult AggiungiVerbale()
        {
            return View();
        }
    }
}
