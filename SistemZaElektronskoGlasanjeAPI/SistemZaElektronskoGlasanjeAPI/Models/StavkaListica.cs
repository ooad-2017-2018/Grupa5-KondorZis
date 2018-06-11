namespace SistemZaElektronskoGlasanjeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StavkaListica")]
    public partial class StavkaListica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StavkaListica()
        {
            Kandidats = new HashSet<Kandidat>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string Utrka_Naziv { get; set; }

        public int? GlasackiListic_Id { get; set; }

        public virtual GlasackiListic GlasackiListic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kandidat> Kandidats { get; set; }

        public virtual Utrka Utrka { get; set; }
    }
}
