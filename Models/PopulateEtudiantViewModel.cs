using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolManagment.Models
{
    public class PopulateEtudiantViewModel
    {
        public string CNE { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Prenom")]
        [Required]
        public string Nickname { get; set; }
        public string Filiere { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}