using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    partial class Kandidat
    {
        string ime, prezime, mjesto_stanovanja;
        Int64 jmbg;
        Nacionalnost n;

        public Kandidat(string ime, string prezime, string mjesto_stanovanja, Int64 jmbg, Nacionalnost n)
        {
            Ime = ime;
            Prezime = prezime;
            Mjesto_stanovanja = mjesto_stanovanja;
            JMBG = jmbg;
            N = n;
        }
        public string ImePrezime { get => ime+" "+prezime; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Mjesto_stanovanja { get => mjesto_stanovanja; set => mjesto_stanovanja = value; }
        public long JMBG { get => jmbg; set => jmbg = (value < 1000000000000 || value > 9999999999999) ? throw new Exception("Pogrešan JMBG"): value; }
        public Nacionalnost N { get => n; set => n = value; }
        public override string ToString()
        {
            return ime +" " + prezime;
        }
    }
}
