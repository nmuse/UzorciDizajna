using nmuse_zadaca_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.ModeliTablice
{
    class TablicaDogadaja : ITablica
    {
        public int Kolo { get; set; }
        public Klub Domacin { get; set; }
        public Klub Gost { get; set; }
        public int Sekunde { get; set; }
        public List<Dogadaj> ListaDogadaja { get; set; }

        public TablicaDogadaja(int kolo, Klub domacin, Klub gost, int sekunde, List<Dogadaj> listaDogadaja)
        {
            Kolo = kolo;
            Domacin = domacin;
            Gost = gost;
            Sekunde = sekunde;
            ListaDogadaja = listaDogadaja;
        }
    }
}
