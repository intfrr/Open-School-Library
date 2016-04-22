using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Open_School_Library.Models;

namespace Open_School_Library.Views
{
    public class DeweysController : Controller
    {
        private OpenSchoolLibraryDBEntities db = new OpenSchoolLibraryDBEntities();

        // GET: Deweys
        public async Task<ActionResult> Index()
        {
            return View(await db.Dewey.ToListAsync());
        }

        // GET: Deweys/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = await db.Dewey.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "id,DeweyDecimalNumber,DeweyCategoryName")] Dewey dewey)
        {
            if (ModelState.IsValid)
            {
                db.Dewey.Add(dewey);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dewey);
        }

        // GET: Deweys/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = await db.Dewey.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "id,DeweyDecimalNumber,DeweyCategoryName")] Dewey dewey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dewey).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dewey);
        }

        // GET: Deweys/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dewey dewey = await db.Dewey.FindAsync(id);
            if (dewey == null)
            {
                return HttpNotFound();
            }
            return View(dewey);
        }

        // POST: Deweys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Dewey dewey = await db.Dewey.FindAsync(id);
            db.Dewey.Remove(dewey);
            await db.SaveChangesAsync();
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
