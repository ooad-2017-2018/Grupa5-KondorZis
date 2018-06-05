using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanje
{
    class GlasackiListic
    {
        List<StavkaListica> izbor;

        public GlasackiListic()
        {
            Izbor = new List<StavkaListica>();
        }

        public List<StavkaListica> Izbor { get => izbor; set => izbor = value; }
    }
}
