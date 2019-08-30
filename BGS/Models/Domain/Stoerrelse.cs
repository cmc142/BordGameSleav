namespace Boardgamesleeves.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stoerrelse")]
    public partial class Stoerrelse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stoerrelse()
        {
            Vare = new HashSet<Vare>();
            Braetspil = new HashSet<Braetspil>();
        }

        public int Stoerrelseid { get; set; }

        public int Bredde { get; set; }

        public int Hoejde { get; set; }

        [Required]
        [StringLength(50)]
        public string StoerrelsesType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vare> Vare { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Braetspil> Braetspil { get; set; }
    }
}
