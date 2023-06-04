using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eDominerUser.Models
{
    public class eDominerUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Plese Enter the Name")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string Name { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNumber { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public string Hobbies { get; set; }
    }
}