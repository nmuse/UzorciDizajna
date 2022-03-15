using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2.Models
{
    class NogometnoPrventsvo : INogometnoPrvenstvo
    {
        public List<Kolo> ListaKola { get; set; }
        public void dodajDijete(INogometnoPrvenstvo dijete)
        {
            ListaKola.Add(dijete as Kolo);
        }
    }
}
