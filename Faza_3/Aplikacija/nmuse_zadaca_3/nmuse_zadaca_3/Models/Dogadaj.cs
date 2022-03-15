using nmuse_zadaca_3.FactoryMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class Dogadaj : INogometnoPrvenstvo
    {
        public int Broj;
        public int Minuta;
        public int Vrsta;
        public Klub Klub;
        public Igrac Igrac;
        public Igrac Zamjena;

        public void dodajDijete(INogometnoPrvenstvo dijete)
        {
            throw new Exception("Nije moguca operacija dodavanja na listu(leaf-u) dogadaja.");
        }
    }
}
