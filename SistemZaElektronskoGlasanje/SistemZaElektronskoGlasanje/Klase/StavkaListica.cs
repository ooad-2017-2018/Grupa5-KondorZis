using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class StavkaListica
    {
        Utrka utrka;
        List<Kandidat> izbor;

        public StavkaListica(Utrka utrka, List<Kandidat> izbor)
        {
            Utrka = utrka;
            Izbor = izbor;
        }

        public Utrka Utrka { get => utrka; set => utrka = value; }
        public List<Kandidat> Izbor { get => izbor; set => izbor = value; }
    }
}
