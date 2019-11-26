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

        public IActionResult Search(string Id)
        {

            List<Trails> trail = TrailDAL.GetResults(Id);
            return View(trail);

            //string key = "200641663-d6ba0e012de562cebaf18e1d1874a93f";
            //HttpWebRequest request = WebRequest.CreateHttp($"https://www.hikingproject.com/data/get-trails-by-id?ids={Id}&key=200641663-d6ba0e012de562cebaf18e1d1874a93f");
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //StreamReader rd = new StreamReader(response.GetResponseStream());
            //string APItext = rd.ReadToEnd();
            //JToken t = JToken.Parse(APItext);
            //Trails d = new Trails(t);
            //return View(d);
        }

        public IActionResult Privacy()
        {
            return View();
        }
            public string UserLevel(int times, string build, string preExisting)
        {
            string uLevel = "";
            if (build == "overweight" || build == "average")
            {
                if (times <= 3)
                {

                    uLevel = "green";

                }
                if (times >= 5 && times >= 3)
                {
                    if (preExisting == "y")

                    {
                        uLevel = "green";
                    }

                    else
                    {
                        uLevel = "greenBlue";
                    }

                }
            }
            if (build == "average" || build == "athletic")
            {
                if (times >= 8)
                {
                    if (preExisting == "Y" && build == "average")
                    {
                        uLevel = "greenBlue";
                    }
                    else
                    {
                        uLevel = "blue";
                    }
                }

                if (times >= 10)
                {
                    if (preExisting == "y" && build == "average")
                    {
                        uLevel = "blue";
                    }
                    else
                    {
                        uLevel = "blueBlack";
                    }
                }
                if (times >= 15)
                {
                    if (preExisting == "y" && build == "average")
                    {
                        uLevel = "blueBlack";
                    }
                    else
                    {
                        uLevel = "Black";
                    }
                }
            }
                    return uLevel;
                
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
