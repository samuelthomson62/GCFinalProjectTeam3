using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }



        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {

            //var build = GetBuild() ;
            //var times = GetTimes();
            //string Condition =GetPreExisitingCondition();
            //ViewBag.Name = "Use is: " + User.Identity.Name;
            //ViewBag.difficulty = "Condition is:" + Condition;
            //ViewBag.Build = "build is: " + build;
            //ViewBag.Build = "times is: " + times;

            //var level = UserLevel();
            //ViewBag.UserLevel = "LEvel is:" + level;
            return View();
        }

        public string GetBuild()
        {

            var bodybuild = from n in _db.UserLevel
                            where n.UserName == User.Identity.Name
                            select n.BodyBuild;

            return bodybuild.Single();
        }
        public int GetTimes()
        {
            var Times = from n in _db.UserLevel
                        where n.UserName == User.Identity.Name
                        select n.TimesDoneBefore;


            return Times.Single();
        }
        public string GetPreExisitingCondition()
        {

            var condition = from n in _db.UserLevel
                            where n.UserName == User.Identity.Name
                            select n.PreExistingCondition;


            return condition.Single();
        }
        public string GetState()
        {

            var state = from n in _db.UserLevel
                        where n.UserName == User.Identity.Name
                        select n.City;


            return state.Single();
        }


        public string UserLevel()
        {
            var PreExistingCondition = GetPreExisitingCondition();
            var BodyBuild = GetBuild();
            var TimesDoneBefore = 5;
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

        //public async Task<IActionResult> TrailsDetail(int? id)

        //    {
        //        {
        //            if (id == null)
        //            {
        //                return NotFound();
        //            }

        //            var trails = await _db.Trails
        //                .Include(t => t.User)
        //                .FirstOrDefaultAsync(m => m.Id == id);
        //            if (trails == null)
        //            {
        //                return NotFound();
        //            }

        //            return View(trails);
        //        }
        //    }

        public IActionResult TrailsDetail(int Id)
        {
            //We have to call the API again to get the trail we want to save.
            Trails x = TrailDAL.GetTrailById(Id);
            return View(x);
        }




        public IActionResult AddToBucketList(string Id, string name, string location, string summary, string image, decimal length)
        {
            //var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);
            string id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var input = new Trails { UserId = id, Location = location, Name = name, Summary = summary, ImgSmallMed = image, Length = length };
            _db.Add(input);
            _db.SaveChanges();



            return RedirectToAction(nameof(BucketList));
        }

        public async Task<IActionResult> BucketList()
        {
            return View(await _db.Trails.ToListAsync());
        }

        //Get
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trails = await _db.Trails
                .FirstOrDefaultAsync(t => t.Id == id);
            if (trails == null)
            {
                return NotFound();
            }

            return View(trails);
        }

        //post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trails = await _db.Trails.FindAsync(id);
            _db.Trails.Remove(trails);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //var trails = await _context.Trails.FindAsync(id);
        //_context.Trails.Remove(trails);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));


        //public IActionResult BucketList()
        //{
        //    return View();
        //}
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
        public IActionResult BucketListDateModal()  //Get
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
