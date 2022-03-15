using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    public class Klub : Clanovi
    {
        public String Kratica { get; set; }
        public String Naziv { get; set; }
        public Trener Trener { get; set; }

        public List<Igrac> Igraci = new List<Igrac>();

        public List<Igrac> dajIgrace()
        {
            return this.Igraci;
        }

        public Klub(string kratica, string naziv, Trener trener)
        {
            Kratica = kratica;
            Naziv = naziv;
            Trener = trener;
        }
        public void dodaj(Igrac igrac)
        {
            this.Igraci.Add(igrac);
        }
    }
}
