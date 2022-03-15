using nmuse_zadaca_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_1
{
    class Prvenstvo
    {
        public List<Dogadaj> ListaDogadaja { get; set; }
        public List<Igrac> ListaIgraca { get; set; }
        public List<Klub> ListaKlubova { get; set; }
        public List<Sastav> ListaSastava { get; set; }
        public List<Utakmica> ListaUtakmica { get; set; }


        private Prvenstvo()
        {
            ListaDogadaja = new List<Dogadaj>();
            ListaIgraca = new List<Igrac>();
            ListaKlubova = new List<Klub>();
            ListaSastava = new List<Sastav>();
            ListaUtakmica = new List<Utakmica>();
    }

        private static Prvenstvo instancaPrvenstva;

        public static Prvenstvo GetInstance()
        {
            if (instancaPrvenstva == null)
            {
                instancaPrvenstva = new Prvenstvo();
            }
            return instancaPrvenstva;
        }









    }
}
