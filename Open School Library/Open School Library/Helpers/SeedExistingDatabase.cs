using Open_School_Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_School_Library.Helpers
{
    public class SeedExistingDatabase
    {
        public static void seedBookTable()
        {
            try
            {
                int isbnCount = 0;
                while (isbnCount < 101)
                {
                    Book book = new Book
                    {
                        Title = "Title",
                        Subtitle = "Subtitle",
                        Author = "Author",
                        Genre = 1,
                        ISBN = isbnCount,
                        Dewey = 1
                    };

                    var context = new OpenSchoolLibraryDBEntities();
                    context.Book.Add(book);
                    context.SaveChanges();

                    isbnCount++;
                }
            }
            catch (Exception)
            {


            }

        }

        public static void seedStudentTable()
        {
            try
            {
                var context = new OpenSchoolLibraryDBEntities();
                context.Database.ExecuteSqlCommand("DELETE FROM Student");

                int count = 0;

                while (count < 101)
                {
                    Random r = new Random();
                    int grade = r.Next(1, 12);
                    int issuedID = r.Next(1, 999);

                    Student student = new Student
                    {
                        FirstName = "First Name",
                        LastName = "Last Name",
                        Grade = grade,
                        Fines = 0,
                        IssuedID = issuedID,
                        StudentEmail = "a@b.com"
                    };


                    context.Student.Add(student);
                    context.SaveChanges();

                    count++;
                }
            }
            catch (Exception)
            {


            }

        }

        public static void seedDeweyTable()
        {
            try
            {
                var context = new OpenSchoolLibraryDBEntities();
                //Can only be used if there are no rows in the Book table.
                //context.Database.ExecuteSqlCommand("DELETE FROM Dewey");

                Dictionary<string, int> deweyDictionary = new Dictionary<string, int>();
                deweyDictionary = DeweyDictionary();

                foreach (var pair in deweyDictionary)
                {
                    Dewey dewey = new Dewey
                    {
                        DeweyName = pair.Key,
                        DeweyNumber = pair.Value
                    };

                    context.Dewey.Add(dewey);
                    context.SaveChanges();
                }
                
            }
            catch (Exception ex)
            {
                

            }

        }

        private static Dictionary<string, int> DeweyDictionary()
        {
            Dictionary<string, int> dewey = new Dictionary<string, int>();

            dewey.Add("General", 000);
            dewey.Add("Philosophy and Psychology", 100);
            dewey.Add("Religion", 200);
            dewey.Add("Social Sciences", 300);
            dewey.Add("Language", 400);
            dewey.Add("Pure Science", 500);
            dewey.Add("Technology", 600);
            dewey.Add("Arts and Recreation", 700);
            dewey.Add("Literature", 800);
            dewey.Add("History and Geography", 900);

            return dewey;
        }
    }
}