using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_School_Library.Models
{
    public class BookListViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ISBN { get; set; }
        public int? Dewey { get; set; }
        public string DewyCategoryName { get; set; }
        public double DeweyDecimalNumber { get; set; }
        public string StudentName { get; set; }
        public DateTime? CheckedOutWhen { get; set; }
        public DateTime? DueBackWhen { get; set; }
        public DateTime? ReturnedWhen { get; set; }
    }
}