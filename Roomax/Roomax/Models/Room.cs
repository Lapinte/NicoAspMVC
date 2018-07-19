using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomax.Models
{
    public class Room : BaseModel
    {
        [Required(ErrorMessage= "Le Nom est obligatoire")]
        [StringLength(50)]
        [Display(Name = "Nom de la salle")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Le Nombre de place est obligatoire")]
        [Range(0,50)]
        [Display(Name = "Nombre de place")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Le Tarif est obligatoire")]
        [Display(Name = "Tarif jour")]
        public decimal Price { get; set; }

        [AllowHtml]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "La Date est obligatoire")]
        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dddd dd MMMM yyyy}")]
        public DateTime CreatedAt { get; set; }

        
        [Display(Name = "Utilisateur")]
        public int? UserID  { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }

        [Display(Name = "Catégorie")]
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
    }
}