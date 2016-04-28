﻿using System;
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
    public class BooksController : Controller
    {
        private OpenSchoolLibraryDBEntities db = new OpenSchoolLibraryDBEntities();

        // GET: Books
        public ActionResult Index(string searchTerm)
        {
            IEnumerable<BookListViewModel> model =
            db.Books
            //.Include(b => b.Dewey_Relation)
            //.Include(b => b.Genres_Relation)
            .OrderByDescending(r => r.title)
            .Where(r => searchTerm == null || r.title.StartsWith(searchTerm))
            .Take(10)
            .Select(r => new BookListViewModel
            {
                title = r.title,
                subtitle = r.subtitle,
                author = r.author,
                genre = r.Genres.genre,
                isbn = r.isbn,

                //TODO: Figureout best way to display Dewey.
                //We only need one reference here.
                //Dewey = r.Dewey,
                //DeweyDecimalNumber = r.DeweyTable.DeweyDecimalNumber,
                dewey_name = r.Dewey1.dewey_name,
                first_name = r.book_loans.FirstOrDefault(w => w.returned_when == null).Students.first_name
                //StudentName = r.book_loans1.StudentsTable.FirstName,
                //StudentName - r.book_loans_Relation.
                //CheckedOutWhen = r.book_loans1.CheckedOutAt,
                //DueBackWhen = r.book_loans1.DueAt,
                //ReturnedWhen = r.book_loans1.ReturnedAt
                //LoanedTo = r.StudentsTable.FirstName,
                //CheckedOutWhen = r.CheckedOutWhen,
                //DueBackWhen = r.DueBackWhen,
                //ReturnedWhen = r.ReturnedWhen
            });
            
            return View(model);

            }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.dewey = new SelectList(db.Dewey, "id", "dewey_name");
            ViewBag.genre = new SelectList(db.Genres, "id", "genre");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,subtitle,author,genre,isbn,dewey,student_id")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dewey = new SelectList(db.Dewey, "id", "dewey_name", books.dewey);
            ViewBag.genre = new SelectList(db.Genres, "id", "genre", books.genre);
            return View(books);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.dewey = new SelectList(db.Dewey, "id", "dewey_name", books.dewey);
            ViewBag.genre = new SelectList(db.Genres, "id", "genre", books.genre);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,subtitle,author,genre,isbn,dewey,student_id")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Entry(books).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dewey = new SelectList(db.Dewey, "id", "dewey_name", books.dewey);
            ViewBag.genre = new SelectList(db.Genres, "id", "genre", books.genre);
            return View(books);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Books books = db.Books.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Books books = db.Books.Find(id);
            db.Books.Remove(books);
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
