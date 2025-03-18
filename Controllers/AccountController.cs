using Microsoft.AspNetCore.Mvc;

namespace TheRealKente.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
