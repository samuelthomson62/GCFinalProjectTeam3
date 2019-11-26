using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.IO;
using System.Net;

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

        public IActionResult Search(string Id)
        {
            string key = "200641663-d6ba0e012de562cebaf18e1d1874a93f";
            HttpWebRequest request = WebRequest.CreateHttp($"https://www.hikingproject.com/data/get-trails-by-id?ids={Id}&key=200641663-d6ba0e012de562cebaf18e1d1874a93f");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APItext = rd.ReadToEnd();
            JToken t = JToken.Parse(APItext);
            Trails d = new Trails(t);
            return View(d);
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
