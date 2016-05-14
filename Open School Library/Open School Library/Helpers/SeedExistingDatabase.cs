using Open_School_Library.Models;
using System;
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
    }
}