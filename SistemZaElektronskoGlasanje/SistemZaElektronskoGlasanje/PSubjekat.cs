using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    abstract class PSubjekat
    {
        string imeSubjekta;
        protected PSubjekat(string imeSubjekta)
        {
            ImeSubjekta = imeSubjekta;
        }
        public string ImeSubjekta { get => imeSubjekta; set => imeSubjekta = value; }
        public override string ToString()
        {
            return imeSubjekta;
        }
    }
}
