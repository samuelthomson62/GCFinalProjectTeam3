using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Search(string Id)
        //{
        //    List<Trails> trail = TrailDAL.GetResults(Id);
        //    return View(trail);
        //}
        public IActionResult Search(string Id, string Difficulty)
        {
            List<Trails> trail = TrailDAL.GetResults(Id, Difficulty);
            return View(trail);
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
