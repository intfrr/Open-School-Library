
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Open_School_Library.Models
{

using System;
    using System.Collections.Generic;
    
public partial class BookLoan
{

    public int BookLoanID { get; set; }

    public int StudentID { get; set; }

    public int BookID { get; set; }

    public System.DateTime CheckedOutWhen { get; set; }

    public System.DateTime DueWhen { get; set; }

    public Nullable<System.DateTime> ReturnedWhen { get; set; }



    public virtual Book Book { get; set; }

    public virtual Student Student { get; set; }

}

}
