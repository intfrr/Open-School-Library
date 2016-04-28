using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Open_School_Library.Models
{
    public class BookListViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int isbn { get; set; }
        public int? dewey { get; set; }
        public string dewey_name { get; set; }
        public double DeweyDecimalNumber { get; set; }
        public string first_name { get; set; }
        public DateTime? CheckedOutWhen { get; set; }
        public DateTime? DueBackWhen { get; set; }
        public DateTime? ReturnedWhen { get; set; }
    }
}