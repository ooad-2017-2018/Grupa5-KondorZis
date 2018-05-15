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
        List<Glasac> glasaci;
        List<ClanKomisije> komisija;

        public List<PSubjekat> Subjekti { get => subjekti; set => subjekti = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }
        public List<ClanKomisije> Komisija { get => komisija; set => komisija = value; }

        public Izbori()
        {
            Subjekti = new List<PSubjekat>();
            Kandidati = new List<Kandidat>();
            Glasaci = new List<Glasac>();
            Komisija = new List<ClanKomisije>();
        }

        public void DodajClana(ClanKomisije ck)
        {
            foreach (ClanKomisije clankom in komisija)
                if (ck.Jmbg == clankom.Jmbg) throw new Exception("Glasač je već unesen");
            Komisija.Add(ck);
        }

        public void ObrisiClana(ClanKomisije ck)
        {
            foreach (ClanKomisije clankom in komisija)
                if (ck.Jmbg == clankom.Jmbg)
                {
                    Komisija.Remove(ck);
                    return;
                }
        }

        public ClanKomisije DajClana(string username)
        {
            foreach (ClanKomisije clankom in komisija)
                if (username == clankom.Username())
                    return clankom;
            throw new Exception("Pogrešan username");
        }

        public void DodajGLasaca(Glasac g)
        {
            foreach (Glasac glasac in glasaci)
                if (g.Jmbg == glasac.Jmbg) throw new Exception("Glasač je već unesen");
            Glasaci.Add(g);
        }

        public void ObrisiGlasaca(Glasac g)
        {
            foreach (Glasac glasac in glasaci)
                if (g.Jmbg == glasac.Jmbg)
                {
                    Glasaci.Remove(glasac);
                    return;
                }
        }

        public Glasac DajGlasaca(Int64 jmbg)
        {
            foreach (Glasac glasac in glasaci)
                if (jmbg == glasac.Jmbg)
                    return glasac;
            throw new Exception("Glasač nije u sistemu");
        }

        public void DodajKandidata(string ime, string prezime, string mjesto_stanovanja, Int64 jmbg, Kandidat.Nacionalnost n)
        {
            foreach (Kandidat k in Kandidati)
                if (k.JMBG == jmbg) throw new Exception("Kandidat je već unesen");
            Kandidati.Add(new Kandidat(ime,prezime,mjesto_stanovanja,jmbg,n));
        }

        public void IzbrisiKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in Kandidati)
                if (k.JMBG == jmbg)
                {
                    Kandidati.Remove(k);
                    return;
                }
        }

        public void DodajStranku(string imeSubjekta, string sjediste)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta==imeSubjekta) throw new Exception("Stranka je već unesena");
            Subjekti.Add(new Stranka(imeSubjekta,sjediste));
        }

        public void DodajNListu(string imeSubjekta)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == imeSubjekta) throw new Exception("Nezavisna lista je već unesena");
            Subjekti.Add(new NezavisnaLista(imeSubjekta));
        }

        public Stranka DajStranku(string ime)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is Stranka) return (ps as Stranka);
                    else
                        throw new Exception(ime + " nije stranka.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public void DodajKandidataS(Kandidat k,string ime)
        {
            foreach (PSubjekat ps in Subjekti)
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
            foreach(PSubjekat ps in Subjekti)
            {
                if (ps.ImeSubjekta == ime) return ps;
            }
            throw new Exception("Politički subjekat nije u sistemu");
        }

        public Kandidat DajKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in Kandidati)
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
                }
                catch(Exception)
                {

                }
            }
        }

        public NezavisnaLista DajNListu(string ime)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is NezavisnaLista) return (ps as NezavisnaLista);
                    else
                        throw new Exception(ime + " nije nezavisna lista.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public void IzbrisiSubjekta(string ime)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == ime)
                {
                    Subjekti.Remove(ps);
                    return;
                }
        }
    }
}
