using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class Izbori
    {
        List<PSubjekat> subjekti;
        List<Kandidat> kandidati;

        public Izbori()
        {
            this.subjekti = new List<PSubjekat>();
            this.kandidati = new List<Kandidat>();
        }

        void DodajKandidata(string ime, string prezime, string mjesto_stanovanja, Int64 jmbg, Kandidat.Nacionalnost n)
        {
            foreach (Kandidat k in kandidati)
                if (k.JMBG == jmbg) throw new Exception("Kandidat je već unesen");
            kandidati.Add(new Kandidat(ime,prezime,mjesto_stanovanja,jmbg,n));
        }

        void IzbrisiKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in kandidati)
                if (k.JMBG == jmbg) kandidati.Remove(k);
        }

        void DodajStranku(string imeSubjekta, string sjediste)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta==imeSubjekta) throw new Exception("Stranka je već unesena");
            subjekti.Add(new Stranka(imeSubjekta,sjediste));
        }


        void DodajNListu(string imeSubjekta)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == imeSubjekta) throw new Exception("Nezavisna lista je već unesena");
            subjekti.Add(new NezavisnaLista(imeSubjekta));
        }
    }
}
