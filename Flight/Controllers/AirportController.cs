using Microsoft.AspNetCore.Mvc;

namespace Flight.Controllers
{
    public class AirportController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
