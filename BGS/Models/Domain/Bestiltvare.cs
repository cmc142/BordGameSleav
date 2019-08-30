namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bestiltvare")]
    public partial class Bestiltvare
    {
        public int Bestiltvareid { get; set; }

        public int Antal { get; set; }

        public int Fakturaid { get; set; }

        [Required]
        [StringLength(100)]
        public string Vareid { get; set; }

        public virtual Faktura Faktura { get; set; }

        public virtual Vare Vare { get; set; }
    }
}
