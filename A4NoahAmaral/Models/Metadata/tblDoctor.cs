using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A4NoahAmaral.Models
{
    [MetadataType(typeof(tblDoctorAttributes))]
    public partial class tblDoctor
    {

    }
    public partial class tblDoctorAttributes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Office is Required")]
        public string Office { get; set; }
        
        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Telephone is Required")]
        [Phone]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
    }
}