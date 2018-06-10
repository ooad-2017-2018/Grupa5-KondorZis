using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public class StavkaListica
    {
        Int32 id;
        Utrka utrka;
        List<Kandidat> izbor;

        public StavkaListica(Utrka utrka, List<Kandidat> izbor)
        {
            Utrka = utrka;
            Izbor = izbor;
        }
        
        public Utrka Utrka { get => utrka; set => utrka = value; }
        public List<Kandidat> Izbor { get => izbor; set => izbor = value; }
        [Key]
        public int Id { get => id; set => id = value; }
    }
}
