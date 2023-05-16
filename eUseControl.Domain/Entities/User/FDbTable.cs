using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eUseControl.Domain.Entities.User
{
    public class FDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        //[Display(Name = "Email Address")]
        //[StringLength(30)]
        //public string Email { get; set; }

        //[Required]
        [Display(Name = "Text")]
        [StringLength(500)]
        public string Text { get; set; }
    }
}
