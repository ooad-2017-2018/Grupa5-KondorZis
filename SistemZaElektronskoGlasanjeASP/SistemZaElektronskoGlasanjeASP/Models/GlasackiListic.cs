using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    class GlasackiListic
    {
        List<StavkaListica> izbor;

        public GlasackiListic(List<StavkaListica> izbor)
        {
            Izbor = izbor;
        }

        public List<StavkaListica> Izbor { get => izbor; set => izbor = value; }
    }
}
