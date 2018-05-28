using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    partial class ClanKomisije
    {
        string ime, prezime,password;
        Ovlastenja ovlasti;
        Int64 jmbg;

        public ClanKomisije(string ime, string prezime, Int64 jmbg, string password, Ovlastenja ovlasti)
        {
            Ime = ime;
            Prezime = prezime;
            Jmbg = jmbg;
            Password = password;
            Ovlasti = ovlasti;
        }
        public string Username()
        {
            return (Ime.Substring(0, 1) + Prezime).ToLower();
        }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Password { get => password; set => password = value; }
        public long Jmbg { get => jmbg; set => jmbg = value; }
        internal Ovlastenja Ovlasti { get => ovlasti; set => ovlasti = value; }
    }
}
