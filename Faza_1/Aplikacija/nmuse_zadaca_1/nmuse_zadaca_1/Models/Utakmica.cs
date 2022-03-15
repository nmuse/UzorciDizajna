using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1.Models
{
    class Utakmica
    {
        public int Broj { get; set; }
        public int Kolo { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public DateTime Pocetak { get; set; }

        public Utakmica(int broj, int kolo, Klub domacin, Klub gost, DateTime pocetak)
        {
            Broj = broj;
            Kolo = kolo;
            Domacin = domacin;
            Gost = gost;
            Pocetak = pocetak;
        }
    }
}
