using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemZaElektronskoGlasanjeASP.Models
{
    public class GlasackiListic
    {
        List<StavkaListica> izbor;
        Int32 id;
        public GlasackiListic(List<StavkaListica> izbor)
        {
            Izbor = izbor;
        }
        
        public List<StavkaListica> Izbor { get => izbor; set => izbor = value; }
        [Key]
        public int Id { get => id; set => id = value; }
    }
}
