﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OpenSchoolLibraryDBEntities : DbContext
    {
        public OpenSchoolLibraryDBEntities()
            : base("name=OpenSchoolLibraryDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<book_loans> book_loans { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Dewey> Dewey { get; set; }
        public virtual DbSet<Genres> Genres { get; set; }
        public virtual DbSet<OSL_Settings> OSL_Settings { get; set; }
        public virtual DbSet<Students> Students { get; set; }
    }
}
