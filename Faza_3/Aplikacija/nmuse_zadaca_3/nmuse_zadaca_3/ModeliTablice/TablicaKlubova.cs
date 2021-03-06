using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.ModeliTablice
{
    class TablicaKlubova : ITablica
    {
        public Klub Klub { get; set; }
        public Trener Trener { get; set; }
        public int BrojOdigranihKola { get; set; }
        public int BrojPobjeda { get; set; }
        public int BrojNerjesenih { get; set; }
        public int BrojPoraza { get; set; }
        public int BrojDanihGolova { get; set; }
        public int BrojPrimljenihGolova { get; set; }
        public int RazlikaGolova { get; set; }
        public int BrojBodova { get; set; }

        public TablicaKlubova(Klub klub, int brojOdigranihKola, int brojPobjeda, int brojNerjesenih, int brojPoraza, int brojDanihGolova, int brojPrimljenihGolova,
            int razlikaGolova, int brojBodova, Trener trener)
        {
            Klub = klub;
            BrojOdigranihKola = brojOdigranihKola;
            BrojPobjeda = brojPobjeda;
            BrojNerjesenih = brojNerjesenih;
            BrojPoraza = brojPoraza;
            BrojDanihGolova = brojDanihGolova;
            BrojPrimljenihGolova = brojPrimljenihGolova;
            RazlikaGolova = razlikaGolova;
            BrojBodova = brojBodova;
            Trener = trener;
        }
    }
}
