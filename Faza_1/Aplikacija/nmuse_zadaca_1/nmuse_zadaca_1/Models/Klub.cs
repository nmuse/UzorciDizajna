using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    class Klub
    {
        public String Kratica { get; set; }
        public String Naziv { get; set; }
        public String Trener { get; set; }

        public Klub(string kratica,string naziv,string trener)
        {
            Kratica = kratica;
            Naziv = naziv;
            Trener = trener;
        }
    }
}
