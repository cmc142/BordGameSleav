namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vare")]
    public partial class Vare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vare()
        {
            Bestiltvare = new HashSet<Bestiltvare>();
        }

        [StringLength(100)]
        public string Vareid { get; set; }

        [Required]
        [StringLength(70)]
        public string Titel { get; set; }

        [DataType("datetime2")]
        public DateTime Oprettelsesdato { get; set; }
              
        public decimal Pris { get; set; }

        [StringLength(100)]
        public string Kategori { get; set; }

        [StringLength(650)]
        public string Beskrivelse { get; set; }

        [StringLength(100)]
        public string Billedsti { get; set; }

        public int LagerAntal { get; set; }

        public int? STK { get; set; }

        public int? Stoerrelseid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestiltvare> Bestiltvare { get; set; }

        public virtual Stoerrelse Stoerrelse { get; set; }
    }
}
