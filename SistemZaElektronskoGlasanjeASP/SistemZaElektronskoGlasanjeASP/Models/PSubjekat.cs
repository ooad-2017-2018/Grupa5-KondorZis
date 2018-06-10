using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public abstract class PSubjekat
    {
        string imeSubjekta;
        protected PSubjekat(string imeSubjekta)
        {
            ImeSubjekta = imeSubjekta;
        }
        [Key]
        public string ImeSubjekta { get => imeSubjekta; set => imeSubjekta = value; }
        public override string ToString()
        {
            return imeSubjekta;
        }
    }
}
