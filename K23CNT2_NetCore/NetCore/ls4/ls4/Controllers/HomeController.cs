using ls4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace nvkLesson04.Controllers
{
    public class nvkHomeController : Controller
    {
        private readonly ILogger<nvkHomeController> _logger;

        public nvkHomeController(ILogger<nvkHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult nvkIndex()
        {
            return View();
        }

        public IActionResult nvkAbout()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}