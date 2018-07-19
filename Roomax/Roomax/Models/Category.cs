using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomax.Models
{
    public class Category : BaseModel
    {
        [Required(ErrorMessage = "Le Nom est obligatoire")]
        [StringLength(50)]
        [Display(Name = "Nom de la catégorie")]
        public string Name { get; set; }
    }
}