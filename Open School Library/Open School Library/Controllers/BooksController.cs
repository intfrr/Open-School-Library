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
    public class BooksController : Controller
    {
        private OpenSchoolLibraryDBEntities db = new OpenSchoolLibraryDBEntities();

        // GET: Books
        public ActionResult Index(string searchTerm)
        {
            IEnumerable<BookListViewModel> model =
            db.Book
            //.Include(b => b.Dewey_Relation)
            //.Include(b => b.Genres_Relation)
            .OrderByDescending(r => r.Title)
            .Where(r => searchTerm == null || r.Title.StartsWith(searchTerm))
            .Take(10)
            .Select(r => new BookListViewModel
            {
                BookID = r.BookID,
                title = r.Title,
                subtitle = r.Subtitle,
                author = r.Author,
                genre = r.Genre1.GenreName,
                isbn = r.ISBN,

                //TODO: Figureout best way to display Dewey.
                //We only need one reference here.
                //Dewey = r.Dewey,
                //DeweyDecimalNumber = r.DeweyTable.DeweyDecimalNumber,
                dewey_name = r.Dewey1.DeweyName,
                first_name = r.BookLoan.FirstOrDefault(w => w.ReturnedWhen == null).Student.FirstName
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
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.dewey = new SelectList(db.Dewey, "DeweyID", "DeweyName");
            ViewBag.genre = new SelectList(db.Genre, "GenreID", "GenreName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookID,Title,Subtitle,Author,Genre,ISBN,Dewey")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dewey = new SelectList(db.Dewey, "id", "dewey_name", book.Dewey);
            ViewBag.genre = new SelectList(db.Genre, "id", "genre", book.Genre);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book books = db.Book.Find(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            ViewBag.dewey = new SelectList(db.Dewey, "DeweyID", "DeweyName", books.Dewey);
            ViewBag.genre = new SelectList(db.Genre, "GenreID", "GenreName", books.Genre);
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookID,Title,Subtitle,Author,Genre,ISBN,Dewey")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dewey = new SelectList(db.Dewey, "DeweyID", "DeweyName", book.Dewey);
            ViewBag.genre = new SelectList(db.Genre, "GenreID", "GenreName", book.Genre);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book books = db.Book.Find(id);
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
            Book books = db.Book.Find(id);
            db.Book.Remove(books);
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
