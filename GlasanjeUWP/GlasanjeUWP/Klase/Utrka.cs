using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    partial class Utrka
    {
        string naziv;
        List<GlasackoMjesto> mjestaZaUtrku;
        List<Kandidat> kandidati;
        List<PSubjekat> subjekti;
        public Tip t;

        public Utrka(string naziv,Tip tip)
        {
            Naziv = naziv;
            MjestaZaUtrku = new List<GlasackoMjesto>();
            Kandidati = new List<Kandidat>();
            Subjekti = new List<PSubjekat>();
            t = tip;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public List<GlasackoMjesto> MjestaZaUtrku { get => mjestaZaUtrku; set => mjestaZaUtrku = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<PSubjekat> Subjekti { get => subjekti; set => subjekti = value; }
    }
}
