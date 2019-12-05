//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace FinalProject.Controllers
//{
//    public class BucketListController : Controller
//    {
//        public IActionResult AddMovie(string Title)
//        {
//            string text = CallMovieAPI(Title);
//            JToken t = JToken.Parse(text);
//            Movies s = new Movies(t);

//            if (s != null)
//            {
//                db.Movie.Add(s);
//                db.SaveChangesAsync();
//                return RedirectToAction(nameof());
//            }
//            else
//            {
//                return RedirectToAction(nameof());
//            }
//        }
//    }
//}