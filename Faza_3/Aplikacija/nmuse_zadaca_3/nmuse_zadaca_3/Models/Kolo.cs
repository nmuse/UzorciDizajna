using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class Kolo : INogometnoPrvenstvo
    {
        List<Utakmica> ListaUtakmica = new List<Utakmica>();
        public int Broj { get; set; }

        public Kolo(int broj)
        {
            Broj = broj;
        }
        public void dodajDijete(INogometnoPrvenstvo dijete)
        {
            ListaUtakmica.Add(dijete as Utakmica);
        }

        public List<Utakmica> dajListuUtakmica()
        {
            return ListaUtakmica;
        }
    }
}
