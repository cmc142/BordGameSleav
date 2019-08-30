namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kunde")]
    public partial class Kunde
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kunde()
        {
            Faktura = new HashSet<Faktura>();
        }

        public int Kundeid { get; set; }

        [Required]
        [StringLength(150)]
        public string Fornavn { get; set; }

        [Required]
        [StringLength(150)]
        public string Efternavn { get; set; }

        [Required]
        [StringLength(150)]
        public string Adresse { get; set; }

        [Required]
        [StringLength(150)]
        public string Bynavn { get; set; }

        public int Postnr { get; set; }

        [Required]
        [StringLength(150)]
        public string Land { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Faktura> Faktura { get; set; }
    }
}
