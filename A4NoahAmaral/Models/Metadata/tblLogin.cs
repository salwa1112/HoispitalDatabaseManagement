using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace A4NoahAmaral.Models
{
    [MetadataType(typeof(tblLoginAttributes))]
    public partial class tblLogin
    {

    }

    public partial class tblLoginAttributes
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is Required")]
        [RegularExpression(@"\S\D+", ErrorMessage = "Invalid Username: Must contain letters [A-Z]")] // RegEx that negates blank space & numerals
        public string Username { get; set; }

        [DataType(DataType.Password)] // Hides input text as asterisks
        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"\S\D+", ErrorMessage = "Invalid Password: Must contain letters [A-Z]")]
        public string Password { get; set; }
    } // END OF LoginAttributes

} // END OF namespace