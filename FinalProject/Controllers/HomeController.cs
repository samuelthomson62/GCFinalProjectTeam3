using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
      


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ApplicationUser U )
        {
           // var build= GetBuild().ToString();
            //string Difficulty = db.difficulty;
            //ViewBag.Build = "Use is: " +User.Identity.Name;
            //ViewBag.difficulty = "zipcode is:"+U.ZipCode;
            //ViewBag.Name = "build is: " + U.BodyBuild;
            return View();
        }

        public string GetBuild()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            var U = User.Identity.Name;
            //string database = "aspnet-FinalProject-48EBCA49-0A7A-4503-967D-42A0DA7D99CD";
            var bodybuild = from n in users
                            where n.UserName == U
                            select  n.BodyBuild;

            

            return bodybuild.ToString();
        }
        public string GetTimes()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            var U = User.Identity.Name;
            var T = from n in users
                                           where n.UserName == U
                                           select n.TimesDoneBefore;

            int Times = T;

            return Times;
        }
        public string GetPreExisitingCondition()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();

            var U = User.Identity.Name;
            //string database = "aspnet-FinalProject-48EBCA49-0A7A-4503-967D-42A0DA7D99CD";
            var condition = from n in users
                            where n.UserName == U
                            select n.PreExistingCondition;

           
            return condition.ToString();
        }

        public string UserLevel()
        {
            string PreExistingCondition = GetPreExisitingCondition();
            int BodyBuild = GetBuild();
            string TimesDoneBefore = GetTimes();
            string difficulty = "";
            //-----------------------------------No preexisting Condition--------------------------------------------
            if (PreExistingCondition == "n")
            {

                // Plump____________________________________________________
                if (BodyBuild == "plump")
                {
                    if (TimesDoneBefore <= 3)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 4 && TimesDoneBefore <= 6)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 8)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 9 && TimesDoneBefore <= 10)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 11 && TimesDoneBefore <= 15)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 15)
                    {
                        difficulty = "blueBlack";
                        return difficulty;
                    }

                }
                // Average____________________________________________________
                if (BodyBuild == "average")
                {
                    if (TimesDoneBefore <= 3)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 4 && TimesDoneBefore <= 6)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 8)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 9 && TimesDoneBefore <= 10)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 11)
                    {
                        difficulty = "black";
                        return difficulty;
                    }

                }
                // Athletic____________________________________________________

                if (BodyBuild == "athletic")
                {
                    if (TimesDoneBefore == 0)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 1 && TimesDoneBefore <= 3)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 4 && TimesDoneBefore <= 6)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 10)
                    {
                        difficulty = "blueBlack";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 11 && TimesDoneBefore <= 15)
                    {
                        difficulty = "black";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 15)
                    {
                        difficulty = "dBlack";
                        return difficulty;
                    }

                }
            }
            //-----------------------------------with preexisting Condition--------------------------------------------
            if (PreExistingCondition == "y")
            {
                // Plump____________________________________________________
                if (BodyBuild == "plump")
                {
                    if (TimesDoneBefore <= 6)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 10)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }

                    if (TimesDoneBefore >= 11)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                }
                // Average____________________________________________________
                if (BodyBuild == "average")
                {
                    if (TimesDoneBefore <= 3)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 4 && TimesDoneBefore <= 6)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 8)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 9 && TimesDoneBefore <= 10)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 11)
                    {
                        difficulty = "blueBlack";
                        return difficulty;
                    }
                }
                // Athletic____________________________________________________
                if (BodyBuild == "athletic")
                {
                    if (TimesDoneBefore == 0)
                    {
                        difficulty = "green";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 1 && TimesDoneBefore <= 3)
                    {
                        difficulty = "greeBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 4 && TimesDoneBefore <= 10)
                    {
                        difficulty = "blue";
                        return difficulty;
                    }

                    if (TimesDoneBefore >= 11 && TimesDoneBefore <= 15)
                    {
                        difficulty = "blueBlack";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 15)
                    {
                        difficulty = "dBlack";
                        return difficulty;
                    }
                }
            }
            return difficulty;
        }
    




    public IActionResult Search(string Id )
        {
            string Difficulty = UserLevel();


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
