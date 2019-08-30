namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Braetspil")]
    public partial class Braetspil
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Braetspil()
        {
            Stoerrelse = new HashSet<Stoerrelse>();
        }

        public int Braetspilid { get; set; }

        [Required]
        [StringLength(50)]
        public string Spilnavn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stoerrelse> Stoerrelse { get; set; }
    }
}
