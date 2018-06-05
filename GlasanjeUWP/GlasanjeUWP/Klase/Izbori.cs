using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    static class Izbori
    {
        static List<PSubjekat> subjekti = new List<PSubjekat>();
        static List<Kandidat> kandidati = new List<Kandidat>();
        static List<Glasac> glasaci = new List<Glasac>();
        static List<ClanKomisije> komisija = new List<ClanKomisije>();
        static List<GlasackoMjesto> gMjesta= new List<GlasackoMjesto>();
        static List<Utrka> utrke = new List<Utrka>();

        public static List<PSubjekat> Subjekti { get => subjekti; set => subjekti = value; }
        public static List<Kandidat> Kandidati { get => kandidati; set => kandidati = value; }
        public static List<Glasac> Glasaci { get => glasaci; set => glasaci = value; }
        public static List<ClanKomisije> Komisija { get => komisija; set => komisija = value; }
        public static List<GlasackoMjesto> GMjesta { get => gMjesta; set => gMjesta = value; }
        public static List<Utrka> Utrke { get => utrke; set => utrke = value; }

        public static List<Utrka> dajUtrkeGlasaca(Glasac g)
        {
            List<Utrka> vracanje = new List<Utrka>();
            foreach (Utrka u in Utrke)
            {
                foreach(GlasackoMjesto gm in u.MjestaZaUtrku)
                {
                    bool e = false;
                    foreach(Glasac gl in gm.ListaRegGlasaca)
                    {
                        if(gl.Jmbg==g.Jmbg)
                        {
                            vracanje.Add(u);
                            e = true;
                            break;
                        }
                    }
                    if(e)
                        break;
                }
            }
            return vracanje;
        }

        public static void DodajGMjesto(GlasackoMjesto gm)
        {
            foreach (GlasackoMjesto glasmj in GMjesta)
                if (glasmj.LokacijaMjesta==gm.LokacijaMjesta) throw new Exception("Glasačko mjesto je već uneseno");
            GMjesta.Add(gm);
        }
        public static void ObrisiGMjesto(string lokacija)
        {
            foreach (GlasackoMjesto clankom in GMjesta)
                if (lokacija==clankom.LokacijaMjesta)
                {
                    GMjesta.Remove(clankom);
                    return;
                }
        }




        public static void DodajClana(ClanKomisije ck)
        {
            foreach (ClanKomisije clankom in komisija)
                if (ck.Jmbg == clankom.Jmbg) throw new Exception("Clan je već unesen");
            Komisija.Add(ck);
        }

        public static void ObrisiClana(Int64 jmb)
        {
            foreach (ClanKomisije clankom in komisija)
                if (jmb == clankom.Jmbg)
                {
                    Komisija.Remove(clankom);
                    return;
                }
        }

        public static ClanKomisije DajClana(string username)
        {
            foreach (ClanKomisije clankom in komisija)
                if (username == clankom.Username())
                    return clankom;
            throw new Exception("Pogrešan username");
        }

        public static void DodajGLasaca(Glasac g,GlasackoMjesto gm)
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

        public static void ObrisiGlasaca(Glasac g)
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

        public static Glasac DajGlasaca(string lkarta)
        {
            foreach (Glasac glasac in glasaci)
                if (lkarta == glasac.BrLicneKarte)
                    return glasac;
            throw new Exception("Glasač nije u sistemu");
        }

        public static void DodajKandidata(string ime, string prezime, string mjesto_stanovanja, Int64 jmbg, Kandidat.Nacionalnost n)
        {
            foreach (Kandidat k in Kandidati)
                if (k.JMBG == jmbg) throw new Exception("Kandidat je već unesen");
            Kandidati.Add(new Kandidat(ime,prezime,mjesto_stanovanja,jmbg,n));
        }

        public static void IzbrisiKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in Kandidati)
                if (k.JMBG == jmbg)
                {
                    Kandidati.Remove(k);
                    return;
                }
        }

        public static void DodajStranku(string imeSubjekta, string sjediste)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta==imeSubjekta) throw new Exception("Stranka je već unesena");
            Subjekti.Add(new Stranka(imeSubjekta,sjediste));
        }

        public static void DodajNListu(string imeSubjekta)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == imeSubjekta) throw new Exception("Nezavisna lista je već unesena");
            Subjekti.Add(new NezavisnaLista(imeSubjekta));
        }

        public static Stranka DajStranku(string ime)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is Stranka) return (ps as Stranka);
                    else
                        throw new Exception(ime + " nije stranka.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public static void DodajKandidataS(Kandidat k,string ime)
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

        public static PSubjekat DajPSubjekta(string ime)
        {
            foreach(PSubjekat ps in Subjekti)
            {
                if (ps.ImeSubjekta == ime) return ps;
            }
            throw new Exception("Politički subjekat nije u sistemu");
        }

        public static Kandidat DajKandidata(Int64 jmbg)
        {
            foreach (Kandidat k in Kandidati)
            {
                if (k.JMBG == jmbg) return k;
            }
            throw new Exception("Kandidat nije u sistemu");
        }

        public static void PromjenaPredsjednika(Kandidat novi,Stranka s)
        {
            s.Predsjednik = novi;
        }

        public static void IzbaciClana(Kandidat k)
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

        public static NezavisnaLista DajNListu(string ime)
        {
            foreach (PSubjekat ps in Subjekti)
                if (ps.ImeSubjekta == ime)
                    if (ps is NezavisnaLista) return (ps as NezavisnaLista);
                    else
                        throw new Exception(ime + " nije nezavisna lista.");
            throw new Exception(ime + " nije u sistemu.");
        }

        public static void IzbrisiSubjekta(string ime)
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
