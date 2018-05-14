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

        public ClanKomisije(string ime, string prezime, string password, Ovlastenja ovlasti)
        {
            Ime = ime;
            Prezime = prezime;
            Password = password;
            Ovlasti = ovlasti;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Password { get => password; set => password = value; }
        internal Ovlastenja Ovlasti { get => ovlasti; set => ovlasti = value; }
    }
}
