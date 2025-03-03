using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Auth()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
