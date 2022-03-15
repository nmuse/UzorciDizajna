using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3.Models
{
    class NogometnoPrventsvo : INogometnoPrvenstvo
    {
        public List<Kolo> ListaKola = new List<Kolo>();
        public void dodajDijete(INogometnoPrvenstvo dijete)
        {
            ListaKola.Add(dijete as Kolo);
        }
        public List<Kolo> dajKola()
        {
            return ListaKola;
        }
    }
}
