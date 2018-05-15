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
        private String sifraZaGlasanje;
        private static Random random = new Random();
        public Glasac() { }
        public Glasac(String _ime, String _prezime, Int64 _jmbg, String _brLicneKarte, String _mjestoStanovanja, String _sifraZaGlasanje)
        {
            this.ime = _ime;
            this.prezime = _prezime;
            this.jmbg = _jmbg;
            this.mjestoStanovanja = _mjestoStanovanja;
            this.brLicneKarte = _brLicneKarte;
            this.sifraZaGlasanje = _sifraZaGlasanje;
        }
        public static string genPass()
        {
            const string chars = "_-.abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //Dodati metodu za prepravku passworda tako da imamo verifikaciju entiteta/distrikta
    }
}
