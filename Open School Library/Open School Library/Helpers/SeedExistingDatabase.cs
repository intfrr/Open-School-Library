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
                while (isbnCount < 101 )
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
    }
}