namespace SistemZaElektronskoGlasanjeAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PSubjekat")]
    public partial class PSubjekat
    {
        [Key]
        public string ImeSubjekta { get; set; }

        public string Sjediste { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public long? Predsjednik_JMBG { get; set; }

        [StringLength(128)]
        public string Utrka_Naziv { get; set; }

        public virtual Kandidat Kandidat { get; set; }

        public virtual Utrka Utrka { get; set; }
    }
}
