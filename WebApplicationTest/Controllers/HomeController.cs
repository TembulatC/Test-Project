using Microsoft.AspNetCore.Mvc;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ClientPage()
        {
            return View();
        }

        public IActionResult AdminPage()
        {
            return View();
        }
    }
}
