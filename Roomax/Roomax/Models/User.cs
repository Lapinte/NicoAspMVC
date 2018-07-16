using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Roomax.Models
{
    public class User
    {
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Nom :")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le champ {0} doit contenir entre {2} et {1} caractères")]
        public string LastName { get; set; }


        [Display(Name = "Prénom :")]
        public string FirstName { get; set; }


        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
ErrorMessage = "L'adresse mail n'est pas au bon format")]

        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Email :")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Date de Naissance :")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }


        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*\W).{6,}$", ErrorMessage = "Le mot de passe ne respecte pas le standart")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Mot de Passe :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Erreur sur la confirmation du mot de passe")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [Display(Name = "Confirmez le Mot De Passe :")]
        [DataType(DataType.Password)]
        public string ComfirmedPassword { get; set; }

    }
}