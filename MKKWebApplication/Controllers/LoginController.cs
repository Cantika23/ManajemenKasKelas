using Microsoft.AspNetCore.Mvc;

namespace MKKWebApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
