using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class Stranka : PSubjekat
    {
        List<Kandidat> clanovi;
        Kandidat predsjednik;
        string sjediste;
        public Stranka(string imeSubjekta,string sjediste) : base(imeSubjekta)
        {
            Clanovi = new List<Kandidat>();
            Sjediste = sjediste;
        }

        public string Sjediste { get => sjediste; set => sjediste = value; }
        internal Kandidat Predsjednik { get => predsjednik; set => predsjednik = value; }
        public List<Kandidat> Clanovi { get => clanovi; set => clanovi = value; }

        public void DodajKandidata(Kandidat k)
        {
            foreach(Kandidat kand in Clanovi)
            {
                if (k.JMBG == kand.JMBG) throw new Exception("Kandidat je već član stranke");
            }
            Clanovi.Add(k);
        }

        public void ObrisiKandidata(Kandidat k)
        {
            foreach (Kandidat kand in Clanovi)
            {
                if (k.JMBG == kand.JMBG)
                {
                    if (kand == Predsjednik)
                        throw new Exception("Ne može se predsjednik izbaciti iz stranke");
                    else
                        Clanovi.Remove(kand);
                    return;
                }
            }
            throw new Exception(k.Ime + " " + k.Prezime + " nije u "+ this.ImeSubjekta);
        }
    }
}
