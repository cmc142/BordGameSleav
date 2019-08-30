using BGS.Infrastructure.Validering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.Models.ViewModels
{
    public class TjekUdViewModel
    {
            [Required(ErrorMessage = "Indtast dit fornavn.")]
            [StringLength(150)]
            [TjekForTegn()]
            public string Fornavn { get; set; }

            [Required(ErrorMessage = "Indtast dit efternavn.")]
            [StringLength(150)]
            [TjekForTegn()]
            public string Efternavn { get; set; }

            [Required(ErrorMessage = "Indtast din adresse.")]
            [TjekForTegn()]
            public string Adresse { get; set; }

            [Required(ErrorMessage = "Indtast navnet på den by du bor.")]
            [StringLength(150)]
            [TjekForTegn()]
            public string Bynavn { get; set; }

            [Required(ErrorMessage = "Indtast dit postnummer.")]
            [DisplayName("Postnummer")]
            [RegularExpression(@"^\d{3,4}$",
                               ErrorMessage = "Et postnummer består af 3 eller 4 tal.")]
            public string Postnr { get; set; }

            [Required(ErrorMessage = "Indtast navnet på det land du bor.")]
            [StringLength(150)]
            [TjekForTegn()]
            public string Land { get; set; }
                        
            [Required(ErrorMessage = "Indtast din mail.")]
            [RegularExpression(@"^[-a-zA-Z0-9æøåÆØÅ][-.a-zA-Z0-9øåæÆØÅ]*@[-.a-zA-Z0-9øåæÆØÅ]+(\.[-.a-zA-Z0-9øæåÆØÅ]+)*\.(com|dk|[a-zA-ZæøåÆØÅ]{2})$",
                               ErrorMessage = "En email er i formatet: xx@xx.xx")]
            public string Email { get; set; }           
        
    }
}