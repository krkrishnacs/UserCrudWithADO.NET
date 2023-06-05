using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eDominerUser.Models
{
    public class State
    {
        public int StateId { get; set; }
        [Required]
        public string StateName { get; set; }
    }
}