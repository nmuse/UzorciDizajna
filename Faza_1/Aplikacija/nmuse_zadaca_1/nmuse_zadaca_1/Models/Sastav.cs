using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    class Sastav
    {
        public int Broj { get; set; }
        public Klub Klub { get; set; }
        public String Vrsta { get; set; }
        public Igrac Igrac { get; set; }
        public String Pozicija { get; set; }



        public Sastav(int broj, Klub klub, String vrsta, Igrac igrac, String pozicija)
        {
            Broj = broj;
            Klub = klub;
            Vrsta = vrsta;
            Igrac = igrac;
            Pozicija = pozicija;
        }

    }
}
