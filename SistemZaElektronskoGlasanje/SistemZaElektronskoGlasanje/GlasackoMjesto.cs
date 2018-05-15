using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class GlasackoMjesto
    {
        private String lokacijaMjesta;
        private List<Glasac> listaRegGlasaca;
        private List<ClanKomisije> listaClanovaKom;
        private List<GlasackiListic> predatiGlasList;
        private static TimeSpan vrijemeIzmedjuAutoPredaje = new TimeSpan(1, 0, 0);
        private TimeSpan vrijemeProslePredaje;
        //public GlasackoMjesto() { }
        public GlasackoMjesto(String _lokacijaMjesta)
        {
            this.lokacijaMjesta = _lokacijaMjesta;
            listaRegGlasaca = new List<Glasac>();
            listaClanovaKom = new List<ClanKomisije>();
            predatiGlasList = new List<GlasackiListic>();
            vrijemeProslePredaje = DateTime.Now.TimeOfDay;
        }
        public int BrojLokalList()
        {
            return predatiGlasList.Count;
        }
        public TimeSpan VrijemeDoAutoPred()
        {
            return vrijemeIzmedjuAutoPredaje - (DateTime.Now.TimeOfDay - this.vrijemeProslePredaje);
        }
        public void PosaljiListice()
        {
            throw new NotImplementedException();
            /*predatiGlasList = new List<GlasackiListic>();
            vrijemeProslePredaje = DateTime.Now.TimeOfDay;*/
        }
        public void DodajNovogGlasaca(Glasac novi)
        {
            foreach (Glasac g in listaRegGlasaca) if (g.Jmbg == novi.Jmbg) throw new Exception("Glasac je vec registrovan na ovom glasackom mjestu");
            listaRegGlasaca.Add(novi); //Keno ce dodati verifikaciju za sva glasacka mjesta
        }
        public void DodajGlasackiListic(GlasackiListic listic)
        {
            predatiGlasList.Add(listic);
        } 
        public void DodajClanaKomisije(ClanKomisije clan)
        {
            foreach (ClanKomisije ck in listaClanovaKom) if (ck.Jmbg == clan.Jmbg) throw new Exception("Clan komisije se vec nalazi u listi za ovo glasacko mjesto");
            listaClanovaKom.Add(clan);
        }
        public void BrisiGlasaca(Glasac zaBr)
        {
            throw new NotImplementedException(); //Napisati pa testirati brisanje
        }
        public void BrisiClanaKomisije(ClanKomisije clan)
        {
            throw new NotImplementedException(); //Napisati pa testirati brisanje
        }
    }
}
