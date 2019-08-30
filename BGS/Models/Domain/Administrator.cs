namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        public int Administratorid { get; set; }

        [Required]
        [StringLength(80)]
        public string Brugernavn { get; set; }

        [Required]
        [StringLength(80)]
        public string Adgangskode { get; set; }
    }
}
