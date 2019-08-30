namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faktura")]
    public partial class Faktura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faktura()
        {
            Bestiltvare = new HashSet<Bestiltvare>();
        }

        public int Fakturaid { get; set; }

        public DateTime Bestillingsdato { get; set; }

        public int Kundeid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestiltvare> Bestiltvare { get; set; }

        public virtual Kunde Kunde { get; set; }
    }
}
