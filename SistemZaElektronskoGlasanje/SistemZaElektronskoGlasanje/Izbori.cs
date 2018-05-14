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

        public void DodajKandidata(string ime, string prezime, string mjesto_stanovanja, Int64 jmbg, Kandidat.Nacionalnost n)
        {
            foreach (Kandidat k in kandidati)
                if (k.JMBG == jmbg) throw new Exception("Kandidat je već unesen");
            kandidati.Add(new Kandidat(ime,prezime,mjesto_stanovanja,jmbg,n));
        }

        public void IzbrisiKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in kandidati)
                if (k.JMBG == jmbg) kandidati.Remove(k);
        }

        public void DodajStranku(string imeSubjekta, string sjediste)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta==imeSubjekta) throw new Exception("Stranka je već unesena");
            subjekti.Add(new Stranka(imeSubjekta,sjediste));
        }

        public void DodajNListu(string imeSubjekta)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == imeSubjekta) throw new Exception("Nezavisna lista je već unesena");
            subjekti.Add(new NezavisnaLista(imeSubjekta));
        }

        public Stranka DajStranku(string ime)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is Stranka) return (ps as Stranka);
                    else
                        throw new Exception(ime + " nije stranka.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public void DodajKandidataS(Kandidat k,string ime)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == ime)
                {
                    if (ps is Stranka) (ps as Stranka).DodajKandidata(k);
                    else (ps as NezavisnaLista).DodajKandidata(k);
                    return;
                }
            throw new Exception(ime + " nije u sistemu.");
        }

        PSubjekat DajPSubjekta(string ime)
        {
            foreach(PSubjekat ps in subjekti)
            {
                if (ps.ImeSubjekta == ime) return ps;
            }
            throw new Exception("Politički subjekat nije u sistemu");
        }

        Kandidat DajKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in kandidati)
            {
                if (k.JMBG == jmbg) return k;
            }
            throw new Exception("Kandidat nije u sistemu");
        }

        public void PromjenaPredsjednika(Kandidat novi,Stranka s)
        {
            s.Predsjednik = novi;
        }

        public void IzbaciClana(Kandidat k)
        {
            foreach (PSubjekat ps in subjekti)
            {
                try
                {
                    if (ps is Stranka)
                        (ps as Stranka).ObrisiKandidata(k);
                    else (ps as NezavisnaLista).ObrisiKandidata(k);
                    return;
                }
                catch(Exception)
                {
                }
            }
            throw new Exception(k.Ime + " " + k.Prezime + " nije u sistemu.");
        }

        public NezavisnaLista DajNListu(string ime)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is NezavisnaLista) return (ps as NezavisnaLista);
                    else
                        throw new Exception(ime + " nije nezavisna lista.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public void IzbrisiSubjekta(string ime)
        {
            foreach (PSubjekat ps in subjekti)
                if (ps.ImeSubjekta == ime) subjekti.Remove(ps);
        }
    }
}
