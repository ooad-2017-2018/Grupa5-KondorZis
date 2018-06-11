namespace SistemZaElektronskoGlasanjeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kandidat")]
    public partial class Kandidat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kandidat()
        {
            PSubjekats = new HashSet<PSubjekat>();
        }

        [Key]
        public long JMBG { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Mjesto_stanovanja { get; set; }

        public int N { get; set; }

        public int? StavkaListica_Id { get; set; }

        [StringLength(128)]
        public string Utrka_Naziv { get; set; }

        public virtual StavkaListica StavkaListica { get; set; }

        public virtual Utrka Utrka { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PSubjekat> PSubjekats { get; set; }
    }
}
