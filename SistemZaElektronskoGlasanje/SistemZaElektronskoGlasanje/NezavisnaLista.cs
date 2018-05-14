using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class NezavisnaLista : PSubjekat
    {
        List<Kandidat> clanovi;
        public NezavisnaLista(string imeSubjekta) : base(imeSubjekta)
        {
            clanovi = new List<Kandidat>();
        }

        void DodajKandidata(Kandidat k)
        {
            foreach (Kandidat kand in clanovi)
            {
                if (k.JMBG == kand.JMBG) throw new Exception("Kandidat je već član stranke");
            }
            clanovi.Add(k);
        }

        void ObrisiKandidata(Kandidat k)
        {
            foreach (Kandidat kand in clanovi)
            {
                if (k.JMBG == kand.JMBG)
                    clanovi.Remove(kand);
            }
        }
    }
}
