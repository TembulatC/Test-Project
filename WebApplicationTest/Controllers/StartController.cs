using System.Diagnostics;
using Domain.Contracts;
using Domain.Services;
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

        [HttpPost]
        [Route("[controller]/[action]")]
        public IActionResult ConfirmAuth()
        {
            return View("ConfirmAuth");
        }
    }
}
