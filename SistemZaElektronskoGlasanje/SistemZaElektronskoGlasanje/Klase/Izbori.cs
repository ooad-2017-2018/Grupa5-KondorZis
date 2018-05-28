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
        List<GlasackoMjesto> gMjesta;

        public List<PSubjekat> Subjekti { get => subjekti; set => subjekti = value; }
        public List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }
        public List<ClanKomisije> Komisija { get => komisija; set => komisija = value; }
        public List<GlasackoMjesto> GMjesta { get => gMjesta; set => gMjesta = value; }

        public Izbori()
        {
            Subjekti = new List<PSubjekat>();
            Kandidati = new List<Kandidat>();
            Glasaci = new List<Glasac>();
            Komisija = new List<ClanKomisije>();
            GMjesta = new List<GlasackoMjesto>();
        }

        public void DodajGMjesto(GlasackoMjesto gm)
        {
            foreach (GlasackoMjesto glasmj in GMjesta)
                if (glasmj.LokacijaMjesta==gm.LokacijaMjesta) throw new Exception("Glasačko mjesto je već uneseno");
            GMjesta.Add(gm);
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

        public void DodajGLasaca(Glasac g,GlasackoMjesto gm)
        {
            foreach (Glasac glasac in glasaci)
                if (g.Jmbg == glasac.Jmbg) throw new Exception("Glasač je već unesen");
            foreach (GlasackoMjesto glasmj in GMjesta)
                if (glasmj.LokacijaMjesta == gm.LokacijaMjesta)
                {
                    gm.DodajNovogGlasaca(g);
                    goto nastavak;
                }
            throw new Exception("Glasačko mjesto je ne postoji");
            nastavak:
            Glasaci.Add(g);
        }

        public void ObrisiGlasaca(Glasac g)
        {
            foreach (Glasac glasac in glasaci)
                if (g.Jmbg == glasac.Jmbg)
                {
                    Glasaci.Remove(glasac);
                    foreach(GlasackoMjesto gm in GMjesta)
                    {
                        foreach(Glasac gl in gm.ListaRegGlasaca)
                        {
                            if (gl.Jmbg == g.Jmbg)
                            {
                                gm.ListaRegGlasaca.Remove(gl);
                                return;
                            }
                        }
                    }
                    return;
                }
            throw new Exception("Nema glasača u sistemu");
        }

        public Glasac DajGlasaca(string lkarta)
        {
            foreach (Glasac glasac in glasaci)
                if (lkarta == glasac.BrLicneKarte)
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
            throw new Exception("Subjekat nije u sistemu");
        }
    }
}
