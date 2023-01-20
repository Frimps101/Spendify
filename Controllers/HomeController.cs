using Microsoft.AspNetCore.Mvc;

namespace Spendify.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
