using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Open_School_Library.Models;

namespace Open_School_Library.Controllers
{
    public class GenresController : Controller
    {
        private OpenSchoolLibraryDBEntities db = new OpenSchoolLibraryDBEntities();

        // GET: Genre
        public ActionResult Index()
        {
            return View(db.Genre.ToList());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre Genre = db.Genre.Find(id);
            if (Genre == null)
            {
                return HttpNotFound();
            }
            return View(Genre);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,genre")] Genre Genre)
        {
            if (ModelState.IsValid)
            {
                db.Genre.Add(Genre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Genre);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre Genre = db.Genre.Find(id);
            if (Genre == null)
            {
                return HttpNotFound();
            }
            return View(Genre);
        }

        // POST: Genre/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,genre")] Genre Genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Genre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Genre);
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre Genre = db.Genre.Find(id);
            if (Genre == null)
            {
                return HttpNotFound();
            }
            return View(Genre);
        }

        // POST: Genre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre Genre = db.Genre.Find(id);
            db.Genre.Remove(Genre);
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
