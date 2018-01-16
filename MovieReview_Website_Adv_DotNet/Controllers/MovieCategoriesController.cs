using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieReview_Website_Adv_DotNet.Models;

namespace MovieReview_Website_Adv_DotNet.Controllers
{
    public class MovieCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MovieCategories
        public ActionResult Index()
        {
            return View(db.MovieCategories.ToList());
        }

        // GET: MovieCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategories.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            return View(movieCategory);
        }

        // GET: MovieCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName")] MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                db.MovieCategories.Add(movieCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieCategory);
        }

        // GET: MovieCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategories.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            return View(movieCategory);
        }

        // POST: MovieCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,CategoryName")] MovieCategory movieCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieCategory);
        }

        // GET: MovieCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieCategory movieCategory = db.MovieCategories.Find(id);
            if (movieCategory == null)
            {
                return HttpNotFound();
            }
            return View(movieCategory);
        }

        // POST: MovieCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieCategory movieCategory = db.MovieCategories.Find(id);
            db.MovieCategories.Remove(movieCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
