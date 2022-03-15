using nmuse_zadaca_3.ModeliTablice;
using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.FactoryMethodTablice
{
    class TablicaStrijelaca : ITablica
    {
        public Igrac Igrac { get; set; }
        public int BrojGolova { get; set; }
        public Klub Klub { get; set; }

        public TablicaStrijelaca(Igrac igrac, int brojGolova, Klub klub)
        {
            Igrac = igrac;
            BrojGolova = brojGolova;
            Klub = klub;
        }
    }
}
