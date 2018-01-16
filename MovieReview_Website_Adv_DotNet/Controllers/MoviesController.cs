using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MovieReview_Website_Adv_DotNet.Models;

namespace MovieReview_Website_Adv_DotNet.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            List<Movie> items = db.Movies.ToList();
            var json = JsonConvert.SerializeObject(items, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            ////var b = json.Length;
            return Content(json);
        }

        public ActionResult ReviewPage()
        {
            return View();
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.MovieCategories, "CategoryId", "CategoryName");
            var CategoryList = new SelectList(db.MovieCategories, "CategoryId", "CategoryName");
            if (Request.IsAjaxRequest())
            {
                //return PartialView("_create");
                var jstring = JsonConvert.SerializeObject(CategoryList, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return Content(jstring);
            }
            else
            {
                return View();
            }
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieName,Review,Name,Email,RatingScore,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                if (Request.IsAjaxRequest())
                {
                    var toDoItems = db.Movies.ToList();
                    var jsonContent = JsonConvert.SerializeObject(movie, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    return Content(jsonContent);
                }

                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.MovieCategories, "CategoryId", "CategoryName", movie.CategoryId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.MovieCategories, "CategoryId", "Name", movie.CategoryId);
            if (Request.IsAjaxRequest())
            {
                //var toDoItems = db.TodoItems.ToList();
                var json = JsonConvert.SerializeObject(movie, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                return Content(json);
            }
            return View(movie); 
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieName,Review,Name,Email,RatingScore,CategoryId")] Movie movie)
        {
            if (ModelState.IsValid)
            {           
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();


                if (Request.IsAjaxRequest())
                {
                    var toDoItems = db.Movies.ToList();
                    var jsonAfter = JsonConvert.SerializeObject(movie, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    return Content(jsonAfter);
                }
            }
            ViewBag.CategoryId = new SelectList(db.MovieCategories, "CategoryId", "CategoryName", movie.CategoryId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            List<Movie> items = db.Movies.ToList();
            var json = JsonConvert.SerializeObject(items, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Content(json);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
