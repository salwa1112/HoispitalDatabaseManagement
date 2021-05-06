using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A4NoahAmaral.Models
{
    [MetadataType(typeof(tblVisitAttributes))]
    public partial class tblVisit
    {

    }
    public partial class tblVisitAttributes
    {
        [Required(ErrorMessage = "Complaint is Required")]
        public string Complaint { get; set; }

        [Required(ErrorMessage = "Date of Admission is Required")]
        public Nullable<System.DateTime> DateOfAdmission { get; set; }

        [Required(ErrorMessage = "Date of Discharge is Required")]
        public Nullable<System.DateTime> DateOfDischarge { get; set; }
    }
}