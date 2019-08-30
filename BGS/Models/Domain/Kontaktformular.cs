using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.Domain
{
    public class Kontaktformular
    {
            [Required(ErrorMessage = "Indtast dit navn")]
            [StringLength(30, MinimumLength = 4)]
            public string Navn { get; set; }

            [Required(ErrorMessage = "Indtast din email")]
            [RegularExpression(@"\S+@(\S+\.)+\w{2,4}", ErrorMessage = "Indtast en email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Angiv et emne")]
            public string Emne { get; set; }

            [Required(ErrorMessage = "Skriv en besked")]
            [StringLength(500, MinimumLength = 6)]
            public string Besked { get; set; }
        
    }
}