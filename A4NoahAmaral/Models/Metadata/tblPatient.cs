using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A4NoahAmaral.Models
{
    [MetadataType(typeof(tblPatientAttributes))]
    public partial class tblPatient
    {

    }
    public partial class tblPatientAttributes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telephone is Required")]
        [Phone]
        public string Telephone { get; set; }

        [DataType(DataType.Date)] // Calendar Format which displays Date without Time
        [Required(ErrorMessage = "Birthdate is Required")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(ErrorMessage = "Health Card Number is Required")]
        [RegularExpression("(^[0-9]{11,11}$)|(^[0-9]{10,10}[A-Z][A-Z]$)", ErrorMessage = "Health Card Number format must be XXXX-XXX-XXX-AA")]
        public string HealthCardNumber { get; set; }
    }
}