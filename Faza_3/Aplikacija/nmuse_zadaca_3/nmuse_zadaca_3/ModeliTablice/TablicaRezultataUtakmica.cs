using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ModeliTablice
{
    class TablicaRezultataUtakmica : ITablica
    {
        public int Kolo { get; set; }
        public DateTime Datum { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public String Rezultat { get; set; }

        public TablicaRezultataUtakmica(int kolo, DateTime datum, Klub domacin, Klub gost, String rezultat)
        {
            Kolo = kolo;
            Datum = datum;
            Domacin = domacin;
            Gost = gost;
            Rezultat = rezultat;
        }
    }
}
