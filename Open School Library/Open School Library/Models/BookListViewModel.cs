using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_School_Library.Models
{
    public class BookListViewModel
    {
        public int BookID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int isbn { get; set; }
        public string dewey_name { get; set; }
        public string genre { get; set; }   
        public BookLoan availability { get; set; }
    }
}