using nmuse_zadaca_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_2
{
    class Prvenstvo
    {
        //public List<Dogadaj> ListaDogadaja { get; set; }
        public List<Klub> ListaKlubova { get; set; }
        //public List<Sastav> ListaSastava { get; set; }
        //public List<Utakmica> ListaUtakmica { get; set; }
        public List<Kolo> ListaKola { get; set; }


        private Prvenstvo()
        {
            //ListaDogadaja = new List<Dogadaj>();
            ListaKlubova = new List<Klub>();
            //ListaSastava = new List<Sastav>();
            //ListaUtakmica = new List<Utakmica>();
            ListaKola = new List<Kolo>();
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
