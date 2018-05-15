using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class Glasac
    {
        private String ime;
        private String prezime;
        private Int64 jmbg;
        private String brLicneKarte;
        private String mjestoStanovanja;
        private static Random random = new Random();

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public long Jmbg { get => jmbg; set => jmbg = (value < 1000000000000 || value > 9999999999999) ? throw new Exception("Pogrešan JMBG") : value; }
        public string BrLicneKarte { get => brLicneKarte; set => brLicneKarte = value; }
        public string MjestoStanovanja { get => mjestoStanovanja; set => mjestoStanovanja = value; }
        
        public Glasac(string ime, string prezime, long jmbg, string brLicneKarte, string mjestoStanovanja)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            BrLicneKarte = brLicneKarte;
            MjestoStanovanja = mjestoStanovanja;
        }
        public string genPass()
        {
            Random random = new Random(Int32.Parse((jmbg% 1000000000).ToString()));
            const string chars = "_-.abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //Dodati metodu za prepravku passworda tako da imamo verifikaciju entiteta/distrikta
    }
}
