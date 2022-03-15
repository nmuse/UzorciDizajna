using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    public abstract class Osoba : Clanovi
    {
        public String Klub { get; set; }
        public String ImePrezime { get; set; }

        public void dodaj(Igrac igrac)
        {
            throw new Exception("Nije moguca operacija dodavanja na listu(leaf-u) osobe.");
        }
    }
}
