using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;


namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
     
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
       // BucketListController bucketListController = new BucketListController();

     
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GeneralSearch(string state)
        {
            List<Trails> trail = TrailDAL.GetResults(state);
            return View(trail);
        }
        
        public IActionResult TrailsDetail(int Id)
        {
            Trails x = TrailDAL.GetTrailById(Id);
            List<Forcast> f = TrailDAL.OpenWeatherGetForcast(x.Location);
            ViewBag.Forcast = f;
            ViewBag.Water = x.Length % 6;
            return View(x);
        }

        
        public IActionResult Disclaimer()
        {
            return View();
        }
        public IActionResult Essentials()
        {
            return View();
        }

        public IActionResult Contact()
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
    }

}
