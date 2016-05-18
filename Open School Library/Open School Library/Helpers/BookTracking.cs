using Open_School_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_School_Library.Helpers
{
    public class BookTracking
    {
        public static bool isBookCheckedOut(int BookID)
        {
            try
            {
                var context = new OpenSchoolLibraryDBEntities();

                var currentBook = from b in context.BookLoan
                                  where b.BookID.Equals(BookID) &&
                                  b.ReturnedWhen.Equals(null)
                                  select b;

                return currentBook.Any() ? true : false;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}