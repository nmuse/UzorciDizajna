using nmuse_zadaca_3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nmuse_zadaca_3
{
    class Prvenstvo
    {
        //public List<Dogadaj> ListaDogadaja { get; set; }
        public List<Klub> ListaKlubova { get; set; }
        //public List<Sastav> ListaSastava { get; set; }
        //public List<Utakmica> ListaUtakmica { get; set; }
        public NogometnoPrventsvo NogometnoPrventsvo { get; set; }
        //public List<Kolo> ListaKola { get; set; }
        public List<Raspored> ListaRasporeda{ get; set; }
        public Raspored vazeciRaspored { get; set; }

        private Prvenstvo()
        {
            //ListaDogadaja = new List<Dogadaj>();
            ListaKlubova = new List<Klub>();
            NogometnoPrventsvo = new NogometnoPrventsvo();
            //ListaSastava = new List<Sastav>();
            //ListaUtakmica = new List<Utakmica>();
            //ListaKola = new List<Kolo>();
            ListaRasporeda = new List<Raspored>();
            vazeciRaspored = null;
            
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
