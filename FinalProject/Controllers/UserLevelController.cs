using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FinalProject.Areas;
using FinalProject.Controllers;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Controllers
{
    public class UserLevelController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserLevelController(ApplicationDbContext db)
        {
            _context = db;
        }

  
        public IActionResult Recomendations()
        {
            return View();
        }

        
        public string GetBuild()
        {
            var bodybuild = from n in _context.UserLevel
                            where n.UserName == User.Identity.Name
                            select n.BodyBuild;

            return bodybuild.Single();
        }
    
        public int GetTimes()
        {
            var Times = from n in _context.UserLevel
                        where n.UserName == User.Identity.Name
                        select n.TimesDoneBefore;


            return Times.Single();
        }
        public string GetPreExisitingCondition()
        {

            var condition = from n in _context.UserLevel
                            where n.UserName == User.Identity.Name
                            select n.PreExistingCondition;


            return condition.Single();
        }
        public string GetState()
        {
            var state = from n in _context.UserLevel
                        where n.UserName == User.Identity.Name
                        select n.State;
            return state.Single();
        }
        public string UserLevel()
        {
            var PreExistingCondition = GetPreExisitingCondition();
            var BodyBuild = GetBuild();
            var TimesDoneBefore = GetTimes() ;
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
                        difficulty = "greenBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 8)
                    {
                        difficulty = "greenBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 9 && TimesDoneBefore <= 10)
                    {
                        difficulty = "greenBlue";
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
                        difficulty = "greenBlue";
                        return difficulty;
                    }
                    if (TimesDoneBefore >= 7 && TimesDoneBefore <= 8)
                    {
                        difficulty = "greenBlue";
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
                        difficulty = "greenBlue";
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
                        difficulty = "greenBlue";
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
                        difficulty = "greenBlue";
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
                        difficulty = "greenBlue";
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

        [Authorize]
        public IActionResult Search()
        {
            if (User.Identity.IsAuthenticated)
            {
                string Difficulty = UserLevel();
                string state = GetState();

                List<Trails> trail = TrailDAL.GetResults(state, Difficulty);
                return View(trail);
            }

            else
            {
                return RedirectToAction("./Identity/Account/Login");
            }
        }

        private bool TrailsExists(int id)
    {
        return _context.Trails.Any(e => e.Id == id);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

}