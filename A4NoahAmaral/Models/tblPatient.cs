//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace A4NoahAmaral.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblPatient
    {
        public tblPatient()
        {
            this.tblVisits = new HashSet<tblVisit>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string HealthCardNumber { get; set; }
    
        public virtual tblDoctor tblDoctor { get; set; }
        public virtual ICollection<tblVisit> tblVisits { get; set; }
    }
}
