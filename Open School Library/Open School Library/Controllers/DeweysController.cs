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
    public class DeweysController : Controller
    {
        private OpenSchoolLibraryDBEntities db = new OpenSchoolLibraryDBEntities();

        // GET: Deweys
        public ActionResult Index()
        {
            return View(db.Dewey.ToList());
        }

        // GET: Deweys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = db.Dewey.Find(id);
            if (dewey == null)
            {
                return HttpNotFound();
            }
            return View(dewey);
        }

        // GET: Deweys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deweys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeweyID,DeweyNumber,DeweyName")] Dewey dewey)
        {
            if (ModelState.IsValid)
            {
                db.Dewey.Add(dewey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dewey);
        }

        // GET: Deweys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = db.Dewey.Find(id);
            if (dewey == null)
            {
                return HttpNotFound();
            }
            return View(dewey);
        }

        // POST: Deweys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeweyID,DeweyNumber,DeweyName")] Dewey dewey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dewey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dewey);
        }

        // GET: Deweys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = db.Dewey.Find(id);
            if (dewey == null)
            {
                return HttpNotFound();
            }
            return View(dewey);
        }

        // POST: Deweys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dewey dewey = db.Dewey.Find(id);
            db.Dewey.Remove(dewey);
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
