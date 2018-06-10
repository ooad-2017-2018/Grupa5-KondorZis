using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    class NezavisnaLista : PSubjekat
    {
        List<Kandidat> clanovi;
        public NezavisnaLista(string imeSubjekta) : base(imeSubjekta)
        {
            clanovi = new List<Kandidat>();
        }

        public void DodajKandidata(Kandidat k)
        {
            foreach (Kandidat kand in clanovi)
            {
                if (k.JMBG == kand.JMBG) throw new Exception("Kandidat je već član stranke");
            }
            clanovi.Add(k);
        }

        public void ObrisiKandidata(Kandidat k)
        {
            foreach (Kandidat kand in clanovi)
            {
                if (k.JMBG == kand.JMBG)
                {
                    clanovi.Remove(kand);
                    return;
                }
            }
            throw new Exception(k.Ime + " " + k.Prezime + " nije u " + this.ImeSubjekta);
        }
    }
}
