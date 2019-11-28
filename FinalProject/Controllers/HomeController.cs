using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {

        ApplicationUser db = new ApplicationUser();
        string uLevel = "";


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
        public IActionResult Search(string Id)
        {
            //ApplicationUser me = new ApplicationUser(User);
            //List<Trails> trail = TrailDAL.GetResults(me.City, me.Difficulty);
            //return View(trail);
            List<Trails> trail = TrailDAL.GetResults(Id, uLevel);
            return View(trail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string UserLevel(int TimesDoneBefore, string BodyBuild, string PreExistingCondition)
        {
            
            if (BodyBuild == "overweight" || BodyBuild == "average")
            {
                if (TimesDoneBefore <= 3)
                {

                    uLevel = "green";

                }
                if (TimesDoneBefore >= 5 && TimesDoneBefore >= 3)
                {
                    if (PreExistingCondition == "y")

                    {
                        uLevel = "green";
                    }

                    else
                    {
                        uLevel = "greenBlue";
                    }

                }
            }
            if (BodyBuild == "average" || BodyBuild == "athletic")
            {
                if (TimesDoneBefore >= 8)
                {
                    if (PreExistingCondition == "Y" && BodyBuild == "average")
                    {
                        uLevel = "greenBlue";
                    }
                    else
                    {
                        uLevel = "blue";
                    }
                }

                if (TimesDoneBefore >= 10)
                {
                    if (PreExistingCondition == "y" && BodyBuild == "average")
                    {
                        uLevel = "blue";
                    }
                    else
                    {
                        uLevel = "blueBlack";
                    }
                }
                if (TimesDoneBefore >= 15)
                {
                    if (PreExistingCondition == "y" && BodyBuild == "average")
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
