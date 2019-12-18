using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GeneralSearch(string state)
        {
            List<Trails> trail = TrailDAL.GetResults(state);
            return View(trail);
        }

        public IActionResult Essentials()
        {
            return View();
        }
        public IActionResult TrailsDetail(int Id)
        {
            //We have to call the API again to get the trail we want to save.
            Trails x = TrailDAL.GetTrailById(Id);
            List<Forcast> f = TrailDAL.OpenWeatherGetForcast(x.Location);
            ViewBag.Forcast = f;
            ViewBag.Water = x.Length % 6;
            return View(x);
        }
        public IActionResult AddCheckMark(int? id)
        {
            var completeMark = "https://solidwize.com/wp-content/uploads/2012/04/Green-Check-Mark.jpg";
            var checkmark =
                from n in _db.Trails
                where n.Id == id
                select n;
            foreach (Trails bl in checkmark)
            {
                if (completeMark == bl.CompleteMark)
                {
                    return RedirectToAction(nameof(AlreadyMarkedCompleted));
                }
                else
                {
                    bl.CompleteMark = completeMark;
                    var user = from n in _db.UserLevel
                               where n.UserName == User.Identity.Name
                               select n;
                    foreach (ApplicationUser u in user)
                    {
                        int current = u.TimesDoneBefore;
                        u.TimesDoneBefore = current + 1;
                        // Insert any additional changes to column values.
                    }
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        // Provide for exceptions.
                    }
                }
            }
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(BucketList));
        }
        public IActionResult AlreadyMarkedCompleted()
        {
            return View();
        }
        public IActionResult MarkIncomplete(int? id)
        {
            var incompleteMark = "https://www.trzcacak.rs/myfile/detail/51-515377_x-mark-transparent-background-png-x.png";
            var checkmark = from n in _db.Trails
                            where n.Id == id
                            select n;
            foreach (Trails bl in checkmark)
            {
                if (incompleteMark == bl.CompleteMark)
                {
                    return RedirectToAction(nameof(BucketList));
                }
                else
                {
                    bl.CompleteMark = incompleteMark;
                    var user = from n in _db.UserLevel
                               where n.UserName == User.Identity.Name
                               select n;

                    foreach (ApplicationUser u in user)
                    {
                        int current = u.TimesDoneBefore;
                        u.TimesDoneBefore = current - 1;
                    }
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            _db.SaveChanges();
            return RedirectToAction(nameof(BucketList));
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddToBucketList(string name, string location, string summary, string image, decimal length, string date)
        {
            if (User.Identity.IsAuthenticated)
            {
                string status = "https://www.trzcacak.rs/myfile/detail/51-515377_x-mark-transparent-background-png-x.png";
                string id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var input = new Trails { UserId = id, Location = location, Name = name, Summary = summary, ImgSmallMed = image, Length = length, Date = date, CompleteMark = status };

                _db.Add(input);
                _db.SaveChanges();

                return RedirectToAction(nameof(Confirm));
            }
            else
            {
                return RedirectToAction("./Identity/Account/Login");
            }
        }

        public IActionResult Confirm()
        {
            return View();
        }

        public IActionResult BucketList()
        {
            string id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Trails> all = _db.Trails.ToList();
            List<Trails> yours = new List<Trails>();
            foreach (Trails t in all)
            {
                if (t.UserId == id.ToString())
                {
                    yours.Add(t);
                }
            }
            return View(yours);
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trails = await _db.Trails.FindAsync(id);
            _db.Trails.Remove(trails);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(BucketList));
        }
        public IActionResult BucketListDateModal()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        private bool TrailsExists(int id)
        {
            return _db.Trails.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                        select n.State;
            return state.Single();
        }
        public string UserLevel()
        {
            var PreExistingCondition = GetPreExisitingCondition();
            var BodyBuild = GetBuild();
            var TimesDoneBefore = GetTimes();
            string difficulty = "";
            //-----------------------------------No preexisting Condition--------------------------------------------
            if (PreExistingCondition == "n")
            {
                // Unathletic____________________________________________________
                if (BodyBuild == "bellow average")
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
                // Unathletic____________________________________________________
                if (BodyBuild == "bellow average")
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
        public IActionResult Contact()
        {
            return View();
        }
    }
}