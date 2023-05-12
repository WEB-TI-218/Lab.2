using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace eUseControl.Web1.Models
{
    public class UserLogin
    {
        //public string Credential { get; internal set; }
        //public string Password { get; internal set; }
        [Required]
        [Display(Name = "Username or Email")]
        public string Credential { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}