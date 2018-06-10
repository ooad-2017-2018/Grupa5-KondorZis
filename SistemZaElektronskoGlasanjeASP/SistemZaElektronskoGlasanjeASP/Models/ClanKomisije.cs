using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public partial class ClanKomisije
    {
        string ime, prezime,password;
        bool ovlasti;
        Int64 jmbg;
        string id;

        public ClanKomisije(string id,string ime, string prezime, Int64 jmbg, string password, bool ovlasti)
        {
            Id = id;
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

        [Key]
        public long Jmbg { get => jmbg; set => jmbg = value; }
        public bool Ovlasti { get => ovlasti; set => ovlasti=value; }
        public string Id { get => id; set => id = value; }

        public Ovlastenja ovlastenja() { return (ovlasti ? Ovlastenja.Upravljanje : Ovlastenja.Nadgledanje); }
    }
}
