//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public string Id { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> Create { get; set; }
        public string CreatedBy { get; set; }
        public string StudentName { get; set; }
        public string StudentSurName { get; set; }
        public string StudentSchool { get; set; }
        public string StudentBirthDate { get; set; }
        public string StudentBirthPlace { get; set; }
        public string StudentExtraInfo { get; set; }
        public Nullable<int> StudentPrice { get; set; }
        public Nullable<int> StudentRestPrice { get; set; }
        public bool Active { get; set; }
        public bool StudentPapier { get; set; }
    }
}