using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class BucketListController : Controller
    {

        private readonly ApplicationDbContext _db;
        public BucketListController(ApplicationDbContext db)
        {
            _db = db;
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
                    var user = from n in _db.ApplicationUser
                               where n.UserName == User.Identity.Name
                               select n;

                    foreach (ApplicationUser u in user)
                    {
                        int current = u.TimesDoneBefore;
                        u.TimesDoneBefore = current + 1;

                    }
                    try
                    {
                        _db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        { Console.WriteLine(e); }
                    }
                }
            }

            try
            { _db.SaveChanges(); }
            catch (Exception e)
            { Console.WriteLine(e); }

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


            var checkmark =
                from n in _db.Trails
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
                    var user = from n in _db.ApplicationUser
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
                        { Console.WriteLine(e); }
                    }
                }
            }

            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
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
                int count = _db.Trails.Count();
                ViewBag.Count = count;
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

        public IActionResult ChangeDate(string date)
        {
            return View();
        }
        public async Task<IActionResult> BucketList()
        {
            return View(await _db.Trails.ToListAsync());
        }
        [Authorize]
 
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

    }
}