using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Open_School_Library.Models
{
    public class BookDetailsViewModel
    {
        public int? bookID { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string author { get; set; }
        public int? isbn { get; set; }
        public string dewey_name { get; set; }
        public string genre { get; set; }

        //Checked out props
        public BookLoan availability { get; set; }
        public string studentFirstName { get; set; }
        public string studentLastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? checkedOutWhen { get; set; }
        public DateTime? dueWhen { get; set; }
    }
}