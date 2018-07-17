using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomax.Models
{
    public class Civility : BaseModel
    {
        [Required(ErrorMessage = "Nom obligatoire")]
        [StringLength(15, ErrorMessage = "Trop long")]
        [Display(Name = "Libéllé :")]
        public string Label { get; set; }
    }
}