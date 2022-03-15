using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class Raspored
    {
        public int broj { get; set; }
        public DateTime kreiran { get; set; }
        public List<ParoviUtakmica> paroviUtakmica = new List<ParoviUtakmica>();

        public void dodajPar(ParoviUtakmica par)
        {
            paroviUtakmica.Add(par);
        }
    }
}
